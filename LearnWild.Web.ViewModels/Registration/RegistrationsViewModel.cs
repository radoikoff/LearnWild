namespace LearnWild.Web.ViewModels.Registration
{
	public class RegistrationsViewModel
    {
        public string CourseId { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string Start { get; set; } = null!;

        public string End { get; set; } = null!;

        public bool InFuture { get; set; }

        public bool HasStarted { get; set; }

        public int? CreditsReceived { get; set; }

        public decimal? Score { get; set; }

        public string Category { get; set; } = null!;

        public string Type { get; set; } = null!;

        public string Teacher { get; set; } = null!;

        public bool IsPaid { get; set; }
    }
}
