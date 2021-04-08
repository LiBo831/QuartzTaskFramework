using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using Topshelf.Core;
using Topshelf.Infrastructure;

namespace Topshelf.EFCore
{
    public class SqlServerDBContext : BaseDBContext, ISqlServerDbContext
    {

        public SqlServerDBContext(IOptions<DbContextOption> option) : base(option)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Option.ConnectionString);
            if (Option.IsOutputSql)
            {
                optionsBuilder.UseLoggerFactory(new EFLoggerFactory());
                optionsBuilder.EnableSensitiveDataLogging(true);
            }
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            base.OnConfiguring(optionsBuilder);
        }

        public override void BulkInsert<T>(IList<T> entities, string destinationTableName = null)
        {
            if (entities == null || !entities.Any()) return;
            if (string.IsNullOrEmpty(destinationTableName))
            {
                var mappingTableName = typeof(T).GetCustomAttribute<TableAttribute>()?.Name;
                destinationTableName = string.IsNullOrEmpty(mappingTableName) ? typeof(T).Name : mappingTableName;
            }
            SqlBulkInsert(entities, destinationTableName);
        }

        private void SqlBulkInsert<T>(IList<T> entities, string destinationTableName = null) where T : class
        {
            using (var dt = entities.ToDataTable())
            {
                dt.TableName = destinationTableName;
                var conn = (SqlConnection)Database.GetDbConnection();
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        var bulk = new SqlBulkCopy(conn, SqlBulkCopyOptions.Default, tran)
                        {
                            BatchSize = entities.Count,
                            DestinationTableName = dt.TableName,
                        };
                        GenerateColumnMappings<T>(bulk.ColumnMappings);
                        bulk.WriteToServerAsync(dt);
                        tran.Commit();
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                        throw;
                    }
                }
                conn.Close();
            }
        }

        private void GenerateColumnMappings<T>(SqlBulkCopyColumnMappingCollection mappings)
            where T : class
        {
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                if (property.GetCustomAttributes<KeyAttribute>().Any())
                {
                    mappings.Add(new SqlBulkCopyColumnMapping(property.Name, typeof(T).Name + property.Name));
                }
                else
                {
                    mappings.Add(new SqlBulkCopyColumnMapping(property.Name, property.Name));
                }
            }
        }

        //public override PaginationResult SqlQueryByPagination<T, TView>(string sql, string[] orderBys, int pageIndex, int pageSize,
        //    Action<TView> eachAction = null)
        //{
        //    var total = SqlQuery<T, int>($"select count(1) from ({sql}) as s").FirstOrDefault();
        //    var jsonResults = SqlQuery<T, TView>(
        //            $"select * from (select *,row_number() over (order by {string.Join(",", orderBys)}) as RowId from ({sql}) as s) as t where RowId between {pageSize * (pageIndex - 1) + 1} and {pageSize * pageIndex} order by {string.Join(",", orderBys)}")
        //        .ToList();
        //    if (eachAction != null)
        //    {
        //        jsonResults = jsonResults.Each(eachAction).ToList();
        //    }

        //    return new PaginationResult(true, string.Empty, jsonResults)
        //    {
        //        pageIndex = pageIndex,
        //        pageSize = pageSize,
        //        total = total
        //    };
        //}


        //public override PaginationResult SqlQueryByPagination<T>(string sql, string[] orderBys, int pageIndex, int pageSize,
        //    params DbParameter[] parameters)
        //{
        //    var total = (int)this.ExecuteScalar($"select count(1) from ({sql}) as s");
        //    var jsonResults = GetDataTable(
        //            $"select * from (select *,row_number() over (order by {string.Join(",", orderBys)}) as RowId from ({sql}) as s) as t where RowId between {pageSize * (pageIndex - 1) + 1} and {pageSize * pageIndex} order by {string.Join(",", orderBys)}")
        //        .ToList<T>();
        //    return new PaginationResult(true, string.Empty, jsonResults)
        //    {
        //        pageIndex = pageIndex,
        //        pageSize = pageSize,
        //        total = total
        //    };
        //}

    }
}
