using ExamsSystem.BusinessLogic.Implementation.Services;
using ExamsSystem.BusinessLogic.Interfaces;
using ExamsSystem.Data.Implementation;
using ExamsSystem.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExamsSystem.Ioc
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            //          // Repositories
            services.AddScoped<IExamRepository, ExamRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();

            // Services
            services.AddScoped<IExamService, ExamService>();
            services.AddScoped<ICourseService, CourseService>();
            return services;
        }
    }
}
