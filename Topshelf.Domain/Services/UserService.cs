using System.Collections.Generic;
using Topshelf.Domain.Repository;
using Topshelf.Models;

namespace Topshelf.Domain.Services
{
    public class UserService : IUserService
    {
        public IUserRepository user { get; set; }

        public IList<Users> GetName()
        {
            return user.Get();
        }
    }

    public interface IUserService
    {
        IList<Users> GetName();
    }
}
