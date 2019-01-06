using System;
using System.Collections.Generic;
using System.Text;
using ExamsSystem.Data.Implementation;
using Microsoft.EntityFrameworkCore;

namespace ExamSystem.Tests.Models
{
    public class DatabaseContextGenerator
    {
        public static DatabaseContext GenerateDbContext()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>().UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ExamSystemTest2;Trusted_Connection=True;").Options;
            return new DatabaseContext(options);
        }
    }
}
