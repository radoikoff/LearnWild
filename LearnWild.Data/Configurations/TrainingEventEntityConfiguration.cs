using LearnWild.Data.Models;
using LearnWild.Data.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnWild.Data.Configurations
{
    public class TrainingEventEntityConfiguration : IEntityTypeConfiguration<TrainingEvent>
    {
        public void Configure(EntityTypeBuilder<TrainingEvent> builder)
        {
            builder.HasOne(x=>x.Teacher)
                   .WithMany(x=>x.TrainingEvents)
                   .HasForeignKey(x=>x.TeacherId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Course)
                   .WithMany(x => x.TrainingEvents)
                   .HasForeignKey(x => x.CourseId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
