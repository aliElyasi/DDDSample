using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commerce.Domain.Core.Base;

namespace Commerce.Domain.Core.UserBoundedContext
{
    public class Admin : AggregateRoot<Guid>
    {
        public string Name { get; private set; }
        public User User { get; private set; }
        private readonly List<Role> _Roles = new List<Role>();

        private Admin(string name, List<Role> roles, User user, Guid id)
        {
            Name = name;
            _Roles = roles;
            this.Id = id;
            User = user;
        }
        private Admin()
        {
            
        }

        public IReadOnlyList<Role> Roles => _Roles;


        public static Admin CreateAdmin(string name, List<Role> roles, User user)
        {
            var admin = new Admin(name, roles, user, Guid.NewGuid());
            return admin;
        }
        public void AddRoles(List<Role> roles)
        {
            _Roles.AddRange(roles);

        }
    }
}