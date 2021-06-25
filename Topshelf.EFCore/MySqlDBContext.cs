using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using Topshelf.Core;
using Topshelf.Infrastructure;

namespace Topshelf.EFCore
{
    public class MySqlDBContext : BaseDBContext
    {
        public MySqlDBContext(IOptions<DbContextOption> option) : base(option)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(Option.ConnectionString, new MySqlServerVersion("5.7.28-mysql"));
            if (Option.IsOutputSql)
            {
                optionsBuilder.UseLoggerFactory(new EFLoggerFactory());
                optionsBuilder.EnableSensitiveDataLogging(true);
            }
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            base.OnConfiguring(optionsBuilder);
        }

        public override void BatchUpdate<T>(IList<T> entities)
        {
            this.BulkUpdate(entities);
        }

        public override void BatchUpdateAsync<T>(IList<T> entities)
        {
            this.BulkUpdateAsync(entities);
        }

        public override void BatchInsert<T>(IList<T> entities)
        {
            this.BulkInsert(entities);
        }

        public override void BatchInsertAsync<T>(IList<T> entities)
        {
            this.BulkInsertAsync(entities);
        }
    }
}
