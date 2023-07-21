using LearnWild.Data.Models.Enums;

namespace LearnWild.Data.Models
{
    public class CourseRegistration
    {
        public Guid StudentId { get; set; }
        public ApplicationUser Student { get; set; } = null!;

        public Guid CourseId { get; set; }
        public Course Course { get; set; } = null!;

        public DateTime AppliedOn { get; set; }

        public DateTime? CompletedOn { get; set; }

        public RegisterStatus Status { get; set; }

        public int? CreditsReceived { get; set; }

        public decimal? Score { get; set; }

        public Guid? OrderId { get; set; }
        public Order? Order { get; set; }
    }
}