using LearnWild.Data.Models;

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

    }
}
