using BClaims.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BClaims.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<IBClaimsDbContext, BClaimsDbContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<BClaimsDbContext>(options =>
               options.UseSqlServer(connectionString)
               .EnableSensitiveDataLogging());

            return services;
        }
    }
}
