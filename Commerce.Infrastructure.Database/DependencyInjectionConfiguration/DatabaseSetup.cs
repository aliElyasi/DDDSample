using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commerce.Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Commerce.Infrastructure.Database.DependencyInjectionConfiguration
{

    public static class DatabaseSetup
    {
        public static void AddDatabaseSetup(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            string connString = configuration.GetConnectionString("DefaultConnection");



            services.AddDbContext<CommerceContext>(options =>
            {
                options.UseSqlServer(connString,
                sqlServerOptionsAction: sqlOptions =>
                {
                    // sqlOptions.MigrationsAssembly(typeof(CommerceContext).Assembly.ToString());
                    // sqlOptions.MigrationsAssembly("Commerce.Infrastructure.Database");

                    sqlOptions.EnableRetryOnFailure();
                });
            });
        }
    }
}