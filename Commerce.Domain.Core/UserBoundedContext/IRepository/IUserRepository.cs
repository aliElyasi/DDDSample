using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commerce.Domain.Core.UserBoundedContext.IRepository
{
    public interface IUserRepository
    {
        public Task<User> GetUser(Guid id);
        public  Task AddUser(User user);
        public Task UpdateUser(User user);
    }
}