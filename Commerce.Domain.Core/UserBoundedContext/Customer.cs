using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commerce.Domain.Core.Base;

namespace Commerce.Domain.Core.UserBoundedContext
{
    public class Customer : AggregateRoot<Guid>
    {

        public Customer(string name, List<Address> address,Guid id)
        {
            Name = name;
            _Addresses = address;
            this.Id=id;
        }
          private Customer()
        {
            
        }

        public  User User { get; private set; }

        public string Name { get; private set; }

        private readonly List<Address> _Addresses = new List<Address>();


        public IReadOnlyList<Address> Addresses => _Addresses;

        
        public static Customer CreateCustomer (string name, List<Address> address)
        {
           return new Customer(name,address,Guid.NewGuid());
        }

            public  void AddAddresses (List<Address> address)
        {
           _Addresses.AddRange(address);
        }
    }
}