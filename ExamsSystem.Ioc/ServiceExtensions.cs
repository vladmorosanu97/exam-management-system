using System.Text;
using ExamsSystem.BusinessLogic.Implementation.Services;
using ExamsSystem.BusinessLogic.Interfaces;
using ExamsSystem.Data.Identity;
using ExamsSystem.Data.Implementation;
using ExamsSystem.Data.Interfaces;
using ExamsSystem.Data.Models.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace ExamsSystem.Ioc
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            var builder = services.AddIdentityCore<User>(o =>
            {
                o.Password.RequireDigit = true;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 8;
                o.User.RequireUniqueEmail = true;
            });

            builder = new IdentityBuilder(builder.UserType, builder.Services);
            builder.AddEntityFrameworkStores<DatabaseContext>();
            builder.AddDefaultTokenProviders();

            
            // Repositories
            services.AddScoped<IExamRepository, ExamRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IClassroomRepository, ClassroomRepository>();
            services.AddScoped<IAppUserManager, AppUserManager>();

            // Services
            services.AddScoped<IExamService, ExamService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IClassroomService, ClassroomService>();
            return services;
        }
    }
}
