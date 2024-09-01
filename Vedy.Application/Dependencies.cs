using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vedy.Infrastructure.Services;

namespace Vedy.Application
{
    public static class Dependencies
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<UserService>();
            services.AddTransient<CompanyService>();
            return services;
        }

    }
}
