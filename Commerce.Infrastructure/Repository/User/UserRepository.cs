using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commerce.Domain.Core.UserBoundedContext.IRepository;
using Commerce.Infrastructure.Database.Context;

namespace Commerce.Infrastructure.Repository.User
{
    public class UserRepository : IUserRepository
    {
        private CommerceContext _context;

        public UserRepository(CommerceContext context)
        {
            _context = context;
        }

        public async Task AddUser(Domain.Core.UserBoundedContext.User user)
        {
         await  _context.AddAsync(user);
        
        }

        public async Task<Domain.Core.UserBoundedContext.User> GetUser(Guid id)
        {
           return await  _context.users.FindAsync(id);
        }

        public async Task UpdateUser(Domain.Core.UserBoundedContext.User user)
        {
            _context.users.Update(user);
        }
    }
}