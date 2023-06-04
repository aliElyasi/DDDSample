using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commerce.Domain.Core.Base;

namespace Commerce.Domain.Core.UserBoundedContext
{
    public class ApplicationFeature : AggregateRoot<Guid>
    {
        public string Name { get; private set; }
        public string Url { get; private set; }

        private readonly List<Role> _Roles = new List<Role>();
        public IReadOnlyList<Role> Roles => _Roles;



        private ApplicationFeature()
        {

        }

        public ApplicationFeature(string name, string url,List<Role> roles,Guid id)
        {
            Name = name;
            Url = url;
            this._Roles=roles;
        }




        public static ApplicationFeature Create(string name, string url,List<Role> roles)
        {

            return new ApplicationFeature(name, url,roles, Guid.NewGuid());

        }


    }

}