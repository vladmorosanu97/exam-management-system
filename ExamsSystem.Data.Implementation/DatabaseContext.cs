using System;
using System.Collections.Generic;
using System.Text;
using ExamsSystem.Data.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamsSystem.Data.Implementation
{
    public sealed class DatabaseContext : DbContext
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
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<ProfessorCourse> ProfessorCourses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>().HasKey(sc => new { sc.StudentId, sc.CourseId });


            modelBuilder.Entity<StudentCourse>()
                .HasOne<Student>(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentId);


            modelBuilder.Entity<StudentCourse>()
                .HasOne<Course>(sc => sc.Course)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.CourseId);

            modelBuilder.Entity<ProfessorCourse>()
                .HasOne<Professor>(pc => pc.Professor)
                .WithMany(p => p.ProfessorCourses)
                .HasForeignKey(sc => sc.ProfessorId);


            modelBuilder.Entity<ProfessorCourse>()
                .HasOne<Course>(pc => pc.Course)
                .WithMany(c => c.ProfessorCourses)
                .HasForeignKey(sc => sc.CourseId);


            modelBuilder.Entity<Professor>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Exams)
                .WithOne(e => e.Course);

            modelBuilder.Entity<Exam>()
                .HasMany(a => a.Classrooms);
        }
    }
}
