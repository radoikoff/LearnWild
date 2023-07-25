namespace LearnWild.Web.ViewModels.Registration
{
    public class StudentScoreViewModel
    {
        public string Id { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public int? Credits { get; set; }

        public decimal? Score { get; set; }
    }
}
