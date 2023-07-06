using LearnWild.Data.Models.Enums;

namespace LearnWild.Data.Models
{
    public class EventRegistration
    {
        public Guid UserId { get; set; }
        public ApplicationUser Student { get; set; } = null!;

        public Guid TrainingEventId { get; set; }
        public TrainingEvent TrainingEvent { get; set; } = null!;

        public DateTime AppliedOn { get; set; }

        public DateTime? ConfirmedOn { get; set; }

        public RegisterStatus Status { get; set; }

        public int? CreditsReceived { get; set; }

        public decimal? Score { get; set; }
    }
}