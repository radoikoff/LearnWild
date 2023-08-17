using System.ComponentModel.DataAnnotations;

namespace LearnWild.Data.Models
{
    public class QuizAttempt
    {
        [Key]
        public Guid Id { get; set; }

        public Guid StudentId { get; set; }
        public ApplicationUser Student { get; set; } = null!;

        public Guid QuizId { get; set; }
        public Quiz Quiz { get; set; } = null!;

        public DateTime StartedAt { get; set; }

        public DateTime? FinishedAt { get; set; }

        public ICollection<StudentResponse> StudentResponses { get; set; } = null!;
    }
}
