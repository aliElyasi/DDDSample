using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commerce.Domain.Core.UserBoundedContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Commerce.Infrastructure.Database.Configurations.UserConfigurations
{
    public class ApplicationFeatureConfiguration : IEntityTypeConfiguration<ApplicationFeature>
    {
        public void Configure(EntityTypeBuilder<ApplicationFeature> builder)
        {
            builder.ToTable("ApplicationFeature", "User");
            builder.HasKey(b => b.Id);


                builder.Navigation(p => p.Roles)
              .UsePropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}