using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commerce.Domain.Core.UserBoundedContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Commerce.Infrastructure.Database.Configurations.UsersConfigurations
{
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.ToTable("Admin","User");
            builder.HasOne(c=>c.User).WithOne().HasForeignKey<Admin>("UserId");
            builder.HasMany(a=>a.Roles).WithMany().UsingEntity(
                l=>l.HasOne(typeof(Role)).WithMany().HasForeignKey("RoleId"),
                r=>r.HasOne(typeof(Admin)).WithMany().HasForeignKey("AdminId")
            );
        }
    }
}