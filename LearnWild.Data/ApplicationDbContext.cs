using LearnWild.Data.Extensions;
using LearnWild.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LearnWild.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<CourseType> CourseTypes { get; set; } = null!;
        public DbSet<CourseRegistration> CourseRegistrations { get; set; } = null!;
        public DbSet<Topic> Topics { get; set; } = null!;
        public DbSet<Resource> Resources { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Quiz> Quizzes { get; set; } = null!;
        public DbSet<Question> Questions { get; set; } = null!;
        public DbSet<Response> Responses { get; set; } = null!;
        public DbSet<QuizAttempt> QuizAttempts { get; set; } = null!;
        public DbSet<StudentResponse> StudentResponses { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            var configAssembly = Assembly.GetAssembly(typeof(ApplicationDbContext)) ??
                                 Assembly.GetExecutingAssembly();

            builder.ApplyConfigurationsFromAssembly(configAssembly);
            builder.SeedData();

            base.OnModelCreating(builder);
        }
    }
}