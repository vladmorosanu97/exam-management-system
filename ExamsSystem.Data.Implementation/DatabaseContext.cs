using ExamsSystem.Data.Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExamsSystem.Data.Implementation
{
    public sealed class DatabaseContext : IdentityDbContext<User, IdentityRole<int>, int>

    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
        {

        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<UserCourse> UserCourses { get; set; }
        public DbSet<ClassroomExam> ClassroomExams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserCourse>()
                .HasOne(pc => pc.User)
                .WithMany(p => p.UserCourses)
                .HasForeignKey(sc => sc.UserId);


            modelBuilder.Entity<UserCourse>()
                .HasOne(pc => pc.Course)
                .WithMany(c => c.UserCourses)
                .HasForeignKey(sc => sc.CourseId);


            modelBuilder.Entity<ClassroomExam>()
                .HasOne<Classroom>(pc => pc.Classroom)
                .WithMany(p => p.ClassroomExams)
                .HasForeignKey(sc => sc.ClassroomId);


            modelBuilder.Entity<ClassroomExam>()
                .HasOne<Exam>(pc => pc.Exam)
                .WithMany(c => c.ClassroomExams)
                .HasForeignKey(sc => sc.ExamId);



            modelBuilder.Entity<Course>()
                .HasMany(c => c.Exams)
                .WithOne(e => e.Course);

            modelBuilder.Entity<User>(b =>
            {
                b.HasKey(u => u.Id);

                b.HasIndex(u => u.NormalizedUserName).HasName("UserNameIndex").IsUnique();
                b.HasIndex(u => u.NormalizedEmail).HasName("EmailIndex");

                b.ToTable("Users");

                b.Property(u => u.UserName).HasMaxLength(256);
                b.Property(u => u.NormalizedUserName).HasMaxLength(256);
                b.Property(u => u.Email).HasMaxLength(256);
                b.Property(u => u.NormalizedEmail).HasMaxLength(256);

            });

            modelBuilder.Entity<IdentityUserClaim<int>>(b =>
            {
                b.ToTable("UserClaims");
            });


            modelBuilder.Entity<IdentityUserLogin<int>> (b =>
            {
                b.ToTable("UserLogins");
            });

            modelBuilder.Entity<IdentityUserToken<int>> (b =>
            {
                b.ToTable("UserTokens");
            });

            modelBuilder.Entity<IdentityRole<int>>(b =>
            {
                b.ToTable("Roles");
            });

            modelBuilder.Entity<IdentityRoleClaim<int>> (b =>
            {
                b.ToTable("RoleClaims");
            });


            modelBuilder.Entity<IdentityUserRole<int>> (b =>
            {
                b.ToTable("UserRoles");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
