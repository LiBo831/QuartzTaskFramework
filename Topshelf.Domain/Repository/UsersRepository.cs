using Topshelf.EFCore;
using Topshelf.Infrastructure;
using Topshelf.Models;

namespace Topshelf.Domain.Repository
{
    public class UsersRepository : BaseRepository<Users, int>, IUsersRepository
    {
        public UsersRepository(IDbContextCore dbContext) 
            : base(dbContext)
        {

        }

    }
}
