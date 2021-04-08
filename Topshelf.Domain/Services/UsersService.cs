using System.Collections.Generic;
using Topshelf.Models;

namespace Topshelf.Domain.Services
{
    public class UsersService : IUsersService
    {
        public IUsersRepository user { get; set; }

        public IList<Users> GetName()
        {
            return user.Get();
        }
    }


}
