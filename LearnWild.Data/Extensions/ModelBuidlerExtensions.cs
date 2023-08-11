using LearnWild.Data.Models;
using LearnWild.Data.Seeding;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LearnWild.Data.Extensions
{
    internal static class ModelBuidlerExtensions
    {
        public static void SeedData(this ModelBuilder builder)
        {
            builder.Entity<IdentityRole<Guid>>().HasData(IdentitySeeder.GenerateApplicationRoles());
            builder.Entity<ApplicationUser>().HasData(IdentitySeeder.GenerateApplicationUsers());
            builder.Entity<IdentityUserRole<Guid>>().HasData(IdentitySeeder.AssignUsersToRoles());

            builder.Entity<Category>().HasData(EntitySeeder.GenerateCategories());
            builder.Entity<CourseType>().HasData(EntitySeeder.GenerateCourseTypes());

            builder.Entity<Course>().HasData(EntitySeeder.GenerateCourses());
            builder.Entity<CourseRegistration>().HasData(EntitySeeder.GenerateCourseRegistrations());
        }
    }
}
