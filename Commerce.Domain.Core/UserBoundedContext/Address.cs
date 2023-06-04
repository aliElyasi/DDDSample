using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commerce.Domain.Core.Base;

namespace Commerce.Domain.Core.UserBoundedContext
{
    public class Address:Entity<Guid>
    {
        private Address(string postalCode, string plaque, float latitude, float longitude, string stringAddress, Customer customer,Guid id)
        {
            PostalCode = postalCode;
            Plaque = plaque;
            Latitude = latitude;
            Longitude = longitude;
            StringAddress = stringAddress;
            this.customer = customer;
            this.Id=id;
        }
        private  Address()
        {
            
        }

        public string PostalCode { get;private set; }
        public string Plaque { get;private set; }
        public float Latitude { get;private set; }
        public float Longitude { get;private set; }
        public string StringAddress { get;private set; }
        public Customer customer { get;private set; }


        public static Address CreateAddress(string postalCode, string plaque, float latitude, float longitude, string stringAddress, Customer customer)
        {
            return new(postalCode,plaque,latitude,longitude,stringAddress,customer,Guid.NewGuid());
        }
        
    } 
}