namespace LearnWild.Web.ViewModels.Course
{
    public class CourseOrderViewModel
    {
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public int Credits { get; set; }

        public decimal Price { get; set; }
    }
}
