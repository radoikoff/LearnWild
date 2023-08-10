namespace LearnWild.Web.ViewModels.Course
{
    public class CourseAllViewModel
    {
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string Start { get; set; } = null!;

        public string End { get; set; } = null!;
        
        public int DurationInDays { get; set; } 

        public bool Active { get; set; }

        public int Credits { get; set; }

        public decimal? Price { get; set; }

        public string Category { get; set; } = null!;

        public string Type { get; set; } = null!;

        public string Teacher { get; set; } = null!;
    }
}
