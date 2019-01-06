using System;
using System.Collections.Generic;
using System.Text;
using ExamsSystem.Data.Implementation;
using ExamsSystem.Data.Interfaces;
using ExamsSystem.Data.Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ExamSystem.Tests.Models
{
    public class UserManagerGenerator
    {
        public static UserManager<User> GenerateUserManager()
        {
            var dbContext = DatabaseContextGenerator.GenerateDbContext();

            IUserStore<User> userStore = new UserStore<User, IdentityRole<int>, DbContext, int>(
                dbContext);

            var identityOption = new IdentityOptions();
            identityOption.Password.RequiredLength = 8;
            identityOption.Password.RequireNonAlphanumeric = false;
            identityOption.Password.RequireDigit = false;
            identityOption.Password.RequireUppercase = false;

            var options = Options.Create(identityOption);
            var userValidators = new List<IUserValidator<User>>();

            var pwdValidators = new List<PasswordValidator<User>>
            {
                new PasswordValidator< User > ()
            };

            return new UserManager<User>(
                userStore,
                options,
                new PasswordHasher<User>(),
                userValidators,
                pwdValidators,
                new UpperInvariantLookupNormalizer(),
                new IdentityErrorDescriber(),
                null,
                new SampleLogger());
        }
    }

    
}


class SampleLogger : ILogger<UserManager<User>>
{
    public IDisposable BeginScope<TState>(TState state)
    {
        return null;
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return logLevel == LogLevel.Trace;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    {
        Console.WriteLine($"Log: {logLevel}; exception = {exception}; ");
    }
}