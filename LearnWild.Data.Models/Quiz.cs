using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static LearnWild.Common.EntityValidationConstants.Quiz;

namespace LearnWild.Data.Models
{
    public class Quiz
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        public Guid CourseId { get; set; }
        public Course Course { get; set; } = null!;

        public ICollection<Question> Questions { get; set; } = new HashSet<Question>();

        public DateTime CreatedOn { get; set; }

        public ICollection<QuizAttempt> QuizAttempts { get; set; } = new HashSet<QuizAttempt>();

    }
}
