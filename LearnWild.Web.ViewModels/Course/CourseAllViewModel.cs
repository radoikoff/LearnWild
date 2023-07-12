namespace LearnWild.Web.ViewModels.Course
{
    public class CourseAllViewModel
    {
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public int Duration { get; set; }

        public int Credits { get; set; }

        public decimal? Price { get; set; }

        public string Category { get; set; } = null!;

        public string Type { get; set; } = null!;
    }
}
