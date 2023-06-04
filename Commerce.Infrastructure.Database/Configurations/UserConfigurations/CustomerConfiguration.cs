using System.Collections.Immutable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commerce.Domain.Core.UserBoundedContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Commerce.Infrastructure.Database.Configurations.UsersConfiguration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer", "User");
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.User).WithOne().HasForeignKey<Customer>("UserId");




            builder.HasMany(c => c.Addresses).WithOne(c => c.customer).HasForeignKey("CustomerId")
                .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);

            
                


        }
    }
}