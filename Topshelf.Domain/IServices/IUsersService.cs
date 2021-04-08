using System.Collections.Generic;
using Topshelf.Models;

namespace Topshelf.Domain
{
    public interface IUsersService
    {
        IList<Users> GetName();
    }
}
