using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commerce.Domain.Core.Base;

namespace Commerce.Domain.Core.UserBoundedContext
{
    public class Role : AggregateRoot<Guid>
    {
        public string Name { get; private set; }

        private readonly List<ApplicationFeature> _ApplicationFeatures = new List<ApplicationFeature>();
        public IReadOnlyList<ApplicationFeature> ApplicationFeatures => _ApplicationFeatures;

        private Role()
        {

        }

        private Role(string name, List<ApplicationFeature> applicationFeatures)
        {
            this.Name = name;
            _ApplicationFeatures = applicationFeatures;

        }

        public static Role CreateRole(string name, List<ApplicationFeature> applicationFeatures)
        {
            var role = new Role(name, applicationFeatures);
            return role;



        }

        public void AddApplicationFeatures(List<ApplicationFeature> applicationFeatures)
        {
            applicationFeatures.AddRange(applicationFeatures);

        }


    }
}