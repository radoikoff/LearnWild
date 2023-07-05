using LearnWild.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnWild.Data.Configurations
{
    internal class RegisteredStudentEntityConfiguration : IEntityTypeConfiguration<EventRegistration>
    {
        public void Configure(EntityTypeBuilder<EventRegistration> builder)
        {
            builder.HasKey(k => new { k.UserId, k.TrainingEventId });

            builder.HasOne(x => x.TrainingEvent)
                   .WithMany(x => x.Registrations)
                   .HasForeignKey(x => x.TrainingEventId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Student)
                   .WithMany(x => x.Registrations)
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
