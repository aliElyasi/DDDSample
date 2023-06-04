using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commerce.Domain.Core.UserBoundedContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Commerce.Infrastructure.Database.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role", "User");
            builder.HasKey(c => c.Id);





            builder.HasMany(c => c.ApplicationFeatures).WithMany(c => c.Roles)

            .UsingEntity(
                l => l.HasOne(typeof(ApplicationFeature)).WithMany().HasForeignKey("ApplicationFeatureId"),

                r => r.HasOne(typeof(Role)).WithMany().HasForeignKey("RoleId")


            );

            builder.Navigation(p => p.ApplicationFeatures)
              .UsePropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}