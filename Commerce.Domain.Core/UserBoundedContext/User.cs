using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commerce.Domain.Core.Base;
using Commerce.Domain.Core.UserBoundedContext.Event;

namespace Commerce.Domain.Core.UserBoundedContext
{
    public class User : AggregateRoot<Guid>
    {
        public string UserName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public bool IsAdmin { get; private set; }
        private User()
        {

        }

        private User(string userName, string email, string password, bool isAdmin, Guid id)
        {
            UserName = userName;
            Email = email;
            Password = password;
            IsAdmin = isAdmin;
            Id = id;
        }



        public static User createUser(string userName, string email, string password, bool isAdmin)
        {

            Guid userId = Guid.NewGuid();
            var user= new User(userName, email, password, isAdmin, userId);
            user.AddDomainEvent(new AddUserEvent(user));
            return user;


        }


    }
}