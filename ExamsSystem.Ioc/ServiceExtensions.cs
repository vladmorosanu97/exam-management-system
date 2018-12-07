using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExamsSystem.Ioc
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
//          services.AddScoped<IReportsService, ReportsService>();
            return services;
        }
    }
}
