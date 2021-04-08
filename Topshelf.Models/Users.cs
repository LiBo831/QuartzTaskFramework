using Microsoft.EntityFrameworkCore.Infrastructure;
using Topshelf.Core;
using Topshelf.EFCore;

namespace Topshelf.Models
{
    [DbContext(typeof(SqlServerDBContext))]
    public class Users : BaseModel<int>
    {
        public override int id { get; set; }
        public string account { get; set; }
        public string name { get; set; }
        public string nickname { get; set; }
        public string picture { get; set; }
        public string password { get; set; }
        public string openid { get; set; }
        public bool manage { get; set; }
    }
}
