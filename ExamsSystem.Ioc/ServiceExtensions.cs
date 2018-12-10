using System;
using System.Collections.Generic;
using System.Text;
using ExamsSystem.BusinessLogic.Implementation.Services;
using ExamsSystem.BusinessLogic.Interfaces;
using ExamsSystem.Data.Implementation;
using ExamsSystem.Data.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExamsSystem.Ioc
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
//          // Repositories
            services.AddScoped<IExamRepository, ExamRepository>();


            // Services
            services.AddScoped<IExamService, ExamService>();
            return services;
        }
    }
}
