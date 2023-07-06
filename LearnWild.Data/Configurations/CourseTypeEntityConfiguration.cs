using LearnWild.Data.Models;
using LearnWild.Data.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnWild.Data.Configurations
{
    public class CourseTypeConfiguration : IEntityTypeConfiguration<CourseType>
    {
        public void Configure(EntityTypeBuilder<CourseType> builder)
        {
            builder.HasData(DatabaseSeeder.GenerateCourseTypes());
        }
    }
}
