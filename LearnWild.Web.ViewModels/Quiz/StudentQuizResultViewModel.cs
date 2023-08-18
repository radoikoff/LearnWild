namespace LearnWild.Web.ViewModels.Quiz
{
	public class StudentQuizResultViewModel
	{
		public string StudentId { get; set; } = null!;

		public int CorrectResponsesCount { get; set; }

		public int TotalResponsesCount { get; set; }
    }
}
