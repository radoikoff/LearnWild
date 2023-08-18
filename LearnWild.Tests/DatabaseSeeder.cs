using LearnWild.Data;
using LearnWild.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnWild.Tests
{
    public class DatabaseSeeder
    {
        private readonly ApplicationDbContext _dbContext;

        public DatabaseSeeder(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public static Category Category = new Category()
        {
            Name = "CategoryOne"
        };

        public static CourseType CourseType = new CourseType()
        {
            Name = "TypeOne"
        };

        public static ApplicationUser Teacher = new ApplicationUser
        {
            UserName = "kenobi@learn.com",
            NormalizedUserName = "KENOBI@LEARN.COM",
            Email = "kenobi@learn.com",
            NormalizedEmail = "KENOBI@LEARN.COM",
            EmailConfirmed = false,
            PasswordHash = "AQAAAAEAACcQAAAAEDwqDa9rwTwD/2+FDuD28EnThOx05Ky+LtxguXhfCoi6vIZEXDtoiHhpDVAyWGdPCw==",
            ConcurrencyStamp = "ad3fb3d0-ab0f-4fc3-91de-d343cb915761",
            SecurityStamp = "885bce7b-936f-4eaa-9068-65cea04a9a4c",
            TwoFactorEnabled = false,
            FirstName = "Obi-Wan",
            LastName = "Kenobi"
        };


        public static Course Course = new Course
        {
            Title = "My First Course",
            Description = "A very long description",
            Start = new DateTime(2023, 02, 15, 0, 0, 0),
            End = new DateTime(2023, 03, 15, 0, 0, 0),
            Active = true,
            Deleted = false,
            Category = Category,
            Type = CourseType,
            MaxCredits = 100,
            Price = null,
            Teacher = Teacher,
            Creator = Teacher,
            CreatedOn = new DateTime(2023, 02, 01, 0, 0, 0),
        };


        public void Seed()
        {
            _dbContext.Users.Add(Teacher);
            _dbContext.Categories.Add(Category);
            _dbContext.CourseTypes.Add(CourseType);

            _dbContext.Courses.Add(Course);

            _dbContext.SaveChanges();
        }
    }
}
