using LearnWild.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnWild.Data.Configurations
{
    public class CourseRegistrationEntityConfiguration : IEntityTypeConfiguration<CourseRegistration>
    {
        public void Configure(EntityTypeBuilder<CourseRegistration> builder)
        {
            builder.HasKey(k => new { k.StudentId, k.CourseId });

            builder.HasOne(x => x.Course)
                   .WithMany(x => x.Registrations)
                   .HasForeignKey(x => x.CourseId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Student)
                   .WithMany(x => x.Registrations)
                   .HasForeignKey(x => x.StudentId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(p => p.Score)
                   .HasPrecision(18, 4);
        }
    }
}
