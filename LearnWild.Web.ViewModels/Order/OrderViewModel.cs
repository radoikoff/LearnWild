using LearnWild.Web.ViewModels.Course;

namespace LearnWild.Web.ViewModels.Order
{
    public class OrderViewModel
    {
        public OrderViewModel()
        {
            Courses = new HashSet<CourseOrderViewModel>();
        }

        public string Id { get; set; } = null!;

        public decimal Subtotal { get; set; }

        public decimal Discount { get; set; }

        public decimal Total { get; set; }

        public ICollection<CourseOrderViewModel> Courses { get; set; }
    }
}
