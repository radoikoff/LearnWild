using LearnWild.Data.Models;
using LearnWild.Data.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnWild.Data.Configurations
{
    public class CourseEntityConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasOne(x=>x.Category)
                   .WithMany(x=>x.Courses)
                   .HasForeignKey(x=>x.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Type)
                   .WithMany(x => x.Courses)
                   .HasForeignKey(x => x.TypeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(p => p.Price)
                   .HasPrecision(18, 4);
        }
    }
}
