using Topshelf.EFCore;
using Topshelf.Models;

namespace Topshelf.Domain
{

    public interface IUsersRepository : IRepository<Users, int>
    {

    }
}
