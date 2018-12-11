using System;
using System.Collections.Generic;
using System.Text;
using ExamsSystem.Data.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamsSystem.Data.Implementation
{
    public sealed class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
        {
           
        }

        public DbSet<Professor> Professors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Professor>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Professor>()
                .HasMany(e => e.Exams)
                .WithOne(e => e.Professor);

            modelBuilder.Entity<Professor>()
                .HasMany(a => a.Courses);

            modelBuilder.Entity<Exam>()
                .HasMany(a => a.Classrooms);
        }
    }
}
