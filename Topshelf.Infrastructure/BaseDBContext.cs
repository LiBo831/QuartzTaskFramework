﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Topshelf.Core;

namespace Topshelf.Infrastructure
{
    public abstract class BaseDBContext : DbContext, IDbContextCore
    {
        public DbContextOption Option { get; }
        public DatabaseFacade GetDatabase() => Database;

        //protected BaseDBContext(DbContextOption option)
        //{
        //    Option = option ?? ServiceLocator.Resolve<IOptions<DbContextOption>>().Value;
        //}
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="option"></param>
        protected BaseDBContext(IOptions<DbContextOption> option)
        {
            if (option == null)
                throw new ArgumentNullException(nameof(option));
            if (string.IsNullOrEmpty(option.Value.ConnectionString))
                throw new ArgumentNullException(nameof(option.Value.ConnectionString));
            //if (string.IsNullOrEmpty(option.Value.ModelAssemblyName))
            //    throw new ArgumentNullException(nameof(option.Value.ModelAssemblyName));
            Option = option.Value;
        }

        //protected BaseDBContext(DbContextOptions options) : base(options)
        //{
        //    Option = ServiceLocator.Resolve<IOptions<DbContextOption>>().Value;
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //optionsBuilder.UseMySql("server=localhost;database=CoreFrameDB;user id=root;password=123456", ServerVersion("5.7.28-mysql"));
        //    if (Option.IsOutputSql)
        //    {
        //        optionsBuilder.UseLoggerFactory(new EFLoggerFactory());
        //        optionsBuilder.EnableSensitiveDataLogging(true);
        //    }
        //    optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        //    base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            MappingEntityTypes(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void MappingEntityTypes(ModelBuilder modelBuilder)
        {
            if (string.IsNullOrEmpty(Option.ModelAssemblyName)) { return; }
            var assembly = Assembly.Load(Option.ModelAssemblyName);
            var types = assembly?.GetTypes().Where(c => c.GetCustomAttributes<DbContextAttribute>().Any());
            var list = types?.Where(t => t.IsImplement(typeof(IBaseModel<>))).ToList();
            if (list != null && list.Any())
            {
                list.ForEach(t =>
                {
                    var dbContextType = t.GetCustomAttributes<DbContextAttribute>().FirstOrDefault(x => x.ContextType == GetType());
                    var entityType = modelBuilder.Model.FindEntityType(t);
                    if (entityType == null && null != dbContextType)
                    {
                        modelBuilder.Model.AddEntityType(t);
                    }
                });
            }
        }


        public new virtual int Add<T>(T entity) where T : class
        {
            base.Add(entity);
            return SaveChanges();
        }

        public virtual async Task<int> AddAsync<T>(T entity) where T : class
        {
            await base.AddAsync(entity);
            return await SaveChangesAsync();
        }

        public virtual int AddRange<T>(ICollection<T> entities) where T : class
        {
            base.AddRange(entities);
            return SaveChanges();
        }

        public virtual async Task<int> AddRangeAsync<T>(ICollection<T> entities) where T : class
        {
            await base.AddRangeAsync(entities);
            return await SaveChangesAsync();
        }

        public virtual int Count<T>(Expression<Func<T, bool>> @where = null) where T : class
        {
            //return CountByCompileQuery(where);
            return where == null ? GetDbSet<T>().Count() : GetDbSet<T>().Count(@where);
        }

        public virtual async Task<int> CountAsync<T>(Expression<Func<T, bool>> @where = null) where T : class
        {
            //return await CountByCompileQueryAsync(where);
            return await (where == null ? GetDbSet<T>().CountAsync() : GetDbSet<T>().CountAsync(@where));
        }

        public virtual int Delete<T, TKey>(TKey key) where T : BaseModel<TKey>
        {
            var entity = Find<T>(key);
            //var entity = GetByCompileQuery<T, TKey>(key);
            Remove(entity);
            return SaveChanges();
        }

        public virtual bool EnsureCreated()
        {
            return Database.EnsureCreated();
        }

        public virtual async Task<bool> EnsureCreatedAsync()
        {
            return await Database.EnsureCreatedAsync();
        }

        /// <summary>
        /// ExecuteSqlWithNonQuery
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public virtual int ExecuteSqlWithNonQuery(string sql, params object[] parameters)
        {
            return Database.ExecuteSqlRaw(sql, parameters);
        }

        public virtual async Task<int> ExecuteSqlWithNonQueryAsync(string sql, params object[] parameters)
        {
            return await Database.ExecuteSqlRawAsync(sql, parameters);
        }

        /// <summary>
        /// edit an entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual int Edit<T>(T entity) where T : class
        {
            //var dbModel = Find<T, TKey>(entity.Id);
            //if (dbModel == null) return -1;
            ////Entry(model).CurrentValues.SetValues(entity);
            //var properties = typeof(T).GetProperties();
            //var changedProperties = new List<string>();
            //foreach (var property in properties)
            //{
            //    var reflector = property.GetReflector();

            //    var value = reflector.GetValue(entity);
            //    var dbvalue = reflector.GetValue(dbModel);
            //    if (value != dbvalue)
            //    {
            //        changedProperties.Add(property.Name);
            //    }
            //}
            base.Update(entity);
            base.Entry(entity).State = EntityState.Modified;
            return SaveChanges();
            //return Update(entity, changedProperties.ToArray());
        }

        /// <summary>
        /// edit entities.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <returns></returns>
        public virtual int EditRange<T>(ICollection<T> entities) where T : class
        {
            GetDbSet<T>().AttachRange(entities.ToArray());
            return SaveChanges();
        }

        public virtual bool Exist<T>(Expression<Func<T, bool>> @where = null) where T : class
        {
            return @where == null ? GetDbSet<T>().Any() : GetDbSet<T>().Any(@where);
            //return CountByCompileQuery(where) > 0;
        }

        public virtual IQueryable<T> FilterWithInclude<T>(Func<IQueryable<T>, IQueryable<T>> include, Expression<Func<T, bool>> @where) where T : class
        {
            var result = GetDbSet<T>().AsQueryable();
            if (where != null)
                result = GetDbSet<T>().Where(where);
            if (include != null)
                result = include(result);
            return result;
        }

        public virtual async Task<bool> ExistAsync<T>(Expression<Func<T, bool>> @where = null) where T : class
        {
            return await Task.FromResult(Exist(where));
            //return await CountByCompileQueryAsync(where) > 0;
        }

        public virtual T Find<T>(object key) where T : class
        {
            return base.Find<T>(key);
        }
        public virtual T Find<T, TKey>(TKey key) where T : BaseModel<TKey>
        {
            return base.Find<T>(key);
            //return GetByCompileQuery<T, TKey>(key);
        }

        public virtual async Task<T> FindAsync<T>(object key) where T : class
        {
            return await base.FindAsync<T>(key);
        }
        public virtual async Task<T> FindAsync<T, TKey>(TKey key) where T : BaseModel<TKey>
        {
            return await base.FindAsync<T>(key);
            //return await GetByCompileQueryAsync<T, TKey>(key);
        }

        public virtual IQueryable<T> Get<T>(Expression<Func<T, bool>> @where = null, bool asNoTracking = false) where T : class
        {
            var query = GetDbSet<T>().AsQueryable();
            if (where != null)
                query = query.Where(where);
            if (asNoTracking)
                query = query.AsNoTracking();
            return query;
        }

        public virtual List<IEntityType> GetAllEntityTypes()
        {
            return Model.GetEntityTypes().ToList();
        }
        public virtual DbSet<T> GetDbSet<T>() where T : class
        {
            if (Model.FindEntityType(typeof(T)) != null)
                return Set<T>();
            throw new Exception($"类型{typeof(T).Name}未在数据库上下文中注册，请先在DbContextOption设置ModelAssemblyName以将所有实体类型注册到数据库上下文中。");
        }

        public virtual T GetSingleOrDefault<T>(Expression<Func<T, bool>> @where = null) where T : class
        {
            return where == null ? GetDbSet<T>().SingleOrDefault() : GetDbSet<T>().SingleOrDefault(where);
            //return FirstOrDefaultByCompileQuery<T>(where);
        }

        public virtual async Task<T> GetSingleOrDefaultAsync<T>(Expression<Func<T, bool>> @where = null) where T : class
        {
            return await (where == null ? GetDbSet<T>().SingleOrDefaultAsync() : GetDbSet<T>().SingleOrDefaultAsync(where));
            //return await FirstOrDefaultByCompileQueryAsync<T>(where);
        }

        /// <summary>
        /// update data by columns.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="updateColumns"></param>
        /// <returns></returns>
        public virtual int Update<T>(T model, params string[] updateColumns) where T : class
        {
            if (updateColumns != null && updateColumns.Length > 0)
            {
                if (Entry(model).State == EntityState.Added ||
                    Entry(model).State == EntityState.Detached) GetDbSet<T>().Attach(model);
                foreach (var propertyName in updateColumns)
                {
                    Entry(model).Property(propertyName).IsModified = true;
                }
            }
            else
            {
                Entry(model).State = EntityState.Modified;
            }
            return SaveChanges();
        }

        public virtual void BatchUpdate<T>(IEnumerable<T> entities) where T : class => throw new NotImplementedException();

        public virtual Task BatchUpdateAsync<T>(IEnumerable<T> entities) where T : class => throw new NotImplementedException();

        //public virtual int Update<T>(Expression<Func<T, bool>> @where, Expression<Func<T, T>> updateFactory) where T : class
        //{
        //    return GetDbSet<T>().Where(where).Update(updateFactory);
        //}

        //public virtual async Task<int> UpdateAsync<T>(Expression<Func<T, bool>> @where, Expression<Func<T, T>> updateFactory) where T : class
        //{
        //    return await GetDbSet<T>().Where(where).UpdateAsync(updateFactory);
        //}

        public virtual int UpdateRange<T>(IEnumerable<T> entities) where T : class
        {
            base.UpdateRange(entities);
            return SaveChanges();
        }

        ///// <summary>
        ///// delete by query.
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="where"></param>
        ///// <returns></returns>
        //public virtual int Delete<T>(Expression<Func<T, bool>> @where) where T : class
        //{
        //    return GetDbSet<T>().Where(@where).Delete();
        //}

        //public virtual async Task<int> DeleteAsync<T>(Expression<Func<T, bool>> @where) where T : class
        //{
        //    return await GetDbSet<T>().Where(@where).DeleteAsync();
        //}

        /// <summary>
        /// bulk insert by sqlbulkcopy, and with transaction.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="entities"></param>
        /// <param name="destinationTableName"></param>
        public virtual void BulkInsertForDatabaseMechanism<T>(IList<T> entities, string destinationTableName = null) where T : class
        {
            if (!Database.IsSqlServer() && !Database.IsMySql())
                throw new NotSupportedException("This method only supports for SQL Server or MySql.");
        }

        public virtual void BatchInsert<T>(IEnumerable<T> entities) where T : class => throw new NotImplementedException();

        public virtual Task BatchInsertAsync<T>(IEnumerable<T> entities) where T : class => throw new NotImplementedException();

        public virtual List<TView> SqlQuery<T, TView>(string sql, params object[] parameters)
            where T : class
        {
            return GetDbSet<T>().FromSqlRaw(sql, parameters).Cast<TView>().ToList();
        }

        public virtual PaginationResult SqlQueryByPagination<T, TView>(string sql, string[] orderBys, int pageIndex, int pageSize,
            Action<TView> eachAction = null) where T : class where TView : class
        {
            throw new NotImplementedException();
        }

        public virtual async Task<List<TView>> SqlQueryAsync<T, TView>(string sql, params object[] parameters)
            where T : class
            where TView : class
        {
            return await GetDbSet<T>().FromSqlRaw(sql, parameters).Cast<TView>().ToListAsync();
        }

        public virtual PaginationResult SqlQueryByPagination<T>(string sql, string[] orderBys, int pageIndex, int pageSize,
            params DbParameter[] parameters) where T : class, new()
        {
            throw new NotImplementedException();
        }

        public T GetByCompileQuery<T, TKey>(TKey id) where T : BaseModel<TKey>
        {
            return EF.CompileQuery((DbContext context, TKey id) => context.Set<T>().Find(id))(this, id);
        }
        public Task<T> GetByCompileQueryAsync<T, TKey>(TKey id) where T : BaseModel<TKey>
        {
            return EF.CompileAsyncQuery((DbContext context, TKey id) => context.Set<T>().Find(id))(this, id);
        }

        public IList<T> GetByCompileQuery<T>(Expression<Func<T, bool>> filter) where T : class
        {
            if (filter == null) filter = m => true;
            return EF.CompileQuery((DbContext context) => context.Set<T>().AsNoTracking().Where(filter).ToList())(this);
        }
        public Task<List<T>> GetByCompileQueryAsync<T>(Expression<Func<T, bool>> filter) where T : class
        {
            if (filter == null) filter = m => true;
            return EF.CompileAsyncQuery((DbContext context) => context.Set<T>().AsNoTracking().Where(filter).ToList())(this);
        }

        public T FirstOrDefaultByCompileQuery<T>(Expression<Func<T, bool>> filter) where T : class
        {
            if (filter == null) filter = m => true;
            return EF.CompileQuery((DbContext context) => context.Set<T>().AsNoTracking().FirstOrDefault(filter))(this);
        }
        public Task<T> FirstOrDefaultByCompileQueryAsync<T>(Expression<Func<T, bool>> filter) where T : class
        {
            if (filter == null) filter = m => true;
            return EF.CompileAsyncQuery((DbContext context) => context.Set<T>().AsNoTracking().FirstOrDefault(filter))(this);
        }
        public T FirstOrDefaultWithTrackingByCompileQuery<T>(Expression<Func<T, bool>> filter) where T : class
        {
            if (filter == null) filter = m => true;
            return EF.CompileQuery((DbContext context) => context.Set<T>().FirstOrDefault(filter))(this);
        }
        public Task<T> FirstOrDefaultWithTrackingByCompileQueryAsync<T>(Expression<Func<T, bool>> filter) where T : class
        {
            if (filter == null) filter = m => true;
            return EF.CompileAsyncQuery((DbContext context) => context.Set<T>().FirstOrDefault(filter))(this);
        }
        public int CountByCompileQuery<T>(Expression<Func<T, bool>> filter) where T : class
        {
            if (filter == null) filter = m => true;
            return EF.CompileQuery((DbContext context) => context.Set<T>().Count(filter))(this);
        }
        public Task<int> CountByCompileQueryAsync<T>(Expression<Func<T, bool>> filter) where T : class
        {
            if (filter == null) filter = m => true;
            return EF.CompileAsyncQuery((DbContext context) => context.Set<T>().Count(filter))(this);
        }
    }
}
