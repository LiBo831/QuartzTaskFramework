using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public override void BatchUpdate<T>(IEnumerable<T> entities) => this.BulkUpdate(entities);

        public override async Task BatchUpdateAsync<T>(IEnumerable<T> entities) => await this.BulkUpdateAsync(entities);

        public override void BatchInsert<T>(IEnumerable<T> entities) => this.BulkInsert(entities);

        public override async Task BatchInsertAsync<T>(IEnumerable<T> entities) => await this.BulkInsertAsync(entities);
    }
}
