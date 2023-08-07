using System.ComponentModel.DataAnnotations;

namespace LearnWild.Web.ViewModels.Course
{
    public class CourseSearchModel
    {

        [Display(Name = "Search")]
        public string? SearchString { get; set; }

        [Display(Name = "Active only")]
        public bool Active { get; set; }

        [Display(Name = "Min")]
        public decimal? MinPrice { get; set; }
        
        [Display(Name = "Max")]
        public decimal? MaxPrice { get; set; }

        public IEnumerable<int>? SelectedCategories { get; set; }
        public IEnumerable<int>? SelectedTypes { get; set; }

        public IEnumerable<OptionsViewModel> Categories { get; set; } = new HashSet<OptionsViewModel>();
        public IEnumerable<OptionsViewModel> Types { get; set; } = new HashSet<OptionsViewModel>();

        public IEnumerable<CourseAllViewModel> Courses { get; set; } = new HashSet<CourseAllViewModel>();
    }
}
