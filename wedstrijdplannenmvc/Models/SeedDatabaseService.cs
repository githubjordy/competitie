using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wedstrijdplannenmvc.Models
{
    public static class SeedDatabaseService
    {
        public static IServiceCollection Seed(this IServiceCollection services)
        {
            //services.AddScoped(typeof(SeedData));
            services.AddScoped<SeedData>();
            
            return services;
        }
    }
}
