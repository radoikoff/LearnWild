using LearnWild.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnWild.Data.Configurations
{
    public class QuestionEntityConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasMany(x => x.StudentResponses)
                   .WithOne(x => x.Question)
                   .HasForeignKey(x => x.QuestionId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
