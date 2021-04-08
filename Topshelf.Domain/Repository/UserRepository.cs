using System.Collections.Generic;
using Topshelf.EFCore;
using Topshelf.Infrastructure;
using Topshelf.Models;

namespace Topshelf.Domain.Repository
{
    public class UserRepository : BaseRepository<Users, int>, IUserRepository
    {
        public UserRepository(IDbContextCore dbContext) 
            : base(dbContext)
        {

        }


    }

    public interface IUserRepository : IRepository<Users, int>
    {
        
    }

}
