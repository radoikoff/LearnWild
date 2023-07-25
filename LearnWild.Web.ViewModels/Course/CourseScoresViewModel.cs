using LearnWild.Web.ViewModels.Registration;

namespace LearnWild.Web.ViewModels.Course
{
    public class CourseScoresViewModel
    {
        public string CourseId { get; set; } = null!;

        public string Title { get; set; } = null!;

        public int MaxCredits { get; set; }

        public IEnumerable<StudentScoreViewModel> Students { get; set; } = new HashSet<StudentScoreViewModel>();
    }
}
