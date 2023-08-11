using LearnWild.Data.Models;
using LearnWild.Data.Models.Enums;

namespace LearnWild.Data.Seeding
{
    internal static class EntitySeeder
    {
        internal static IEnumerable<Category> GenerateCategories()
        {
            return new List<Category>()
            {
                new Category()
                {
                     Id = 1,
                     Name = "IT and Software",
                },
                new Category()
                {
                     Id= 2,
                     Name = "Business"
                },
                new Category()
                {
                     Id= 3,
                     Name = "Finance and Accounting"
                },
                new Category()
                {
                     Id= 4,
                     Name = "Personal Development"
                },
                new Category()
                {
                     Id= 5,
                     Name = "Desing"
                },
                new Category()
                {
                     Id= 6,
                     Name = "Lifestyle"
                }
            };
        }

        internal static IEnumerable<CourseType> GenerateCourseTypes()
        {
            return new List<CourseType>()
            {
                new CourseType()
                {
                    Id = 1,
                    Name = "Online"
                },
                new CourseType()
                {
                    Id = 2,
                    Name = "ILT"
                }
            };
        }

        internal static IEnumerable<Course> GenerateCourses()
        {
            return new List<Course>()
            {
                new Course()
                {
                    Id = Guid.Parse("2cf5e1e6-dc12-428d-950a-c06fc8dbc6c1"),
                    CategoryId = 1,
                    TypeId = 1,
                    TeacherId = Guid.Parse("86522b7c-9752-4b0d-a327-59cd8bf8dd62"), //Obi wan
                    Title = "Programming Basics with C#",
                    Description = "An basic course for programming on C# language. Suitable for beginners.",
                    CreatedBy = Guid.Parse("86522b7c-9752-4b0d-a327-59cd8bf8dd62"),
                    CreatedOn = new DateTime(2023, 8, 1, 12, 0, 0),
                    Start = new DateTime(2023,8,15,18,0,0),
                    End = new DateTime(2023,8,20,18,0,0),
                    Active = true,
                    Deleted = false,
                    MaxCredits = 100,
                    Price = null
                },
                new Course()
                {
                    Id = Guid.Parse("9d68dc84-acba-4707-8bd9-9504876fe16e"),
                    CategoryId = 5,
                    TypeId = 1,
                    TeacherId = Guid.Parse("86522b7c-9752-4b0d-a327-59cd8bf8dd62"), //Obi wan
                    Title = "How to design good looking houses",
                    Description = "An extensive course about design concepts for wooden houses.",
                    CreatedBy = Guid.Parse("86522b7c-9752-4b0d-a327-59cd8bf8dd62"),
                    CreatedOn = new DateTime(2023, 7, 3, 12, 0, 0),
                    Start = new DateTime(2023, 8, 10, 14, 0, 0),
                    End = new DateTime(2023, 9, 8, 14, 0, 0),
                    Active = true,
                    Deleted = false,
                    Price = 450
                },
                new Course()
                {
                    Id = Guid.Parse("442d5e89-02d5-4ab3-ae76-07035dffebf1"),
                    CategoryId = 4,
                    TypeId = 2,
                    TeacherId = Guid.Parse("386db847-7c35-4281-a8c6-acd00de18424"), //Vader
                    Title = "How to become better manager.",
                    Description = "An advanced course for project management in software industry",
                    CreatedBy = Guid.Parse("386db847-7c35-4281-a8c6-acd00de18424"),
                    CreatedOn = new DateTime(2023, 7, 23, 13, 23,0),
                    Start = new DateTime(2023,9,15,11,0,0),
                    End = new DateTime(2023,9,20,11,0,0),
                    Active = true,
                    Deleted = false,
                    Price = 300
                }
            };
        }

        internal static IEnumerable<CourseRegistration> GenerateCourseRegistrations()
        {
            return new List<CourseRegistration>()
            {
                new CourseRegistration()
                {
                     CourseId = Guid.Parse("2cf5e1e6-dc12-428d-950a-c06fc8dbc6c1"), //Obi course
                     StudentId = Guid.Parse("c3dba02e-2e03-4989-81c5-c8288f264c64"), //Student
                     AppliedOn = new DateTime(2023, 08, 05, 18, 32, 10),
                     Status = RegisterStatus.Completed,
                     CompletedOn = new DateTime(2023, 08, 05, 18, 32, 20),
                },
            };
        }

    }
}
