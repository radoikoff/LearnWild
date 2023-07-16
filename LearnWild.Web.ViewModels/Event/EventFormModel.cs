using LearnWild.Web.ViewModels.Course;
using LearnWild.Web.ViewModels.User;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace LearnWild.Web.ViewModels.Event
{
    public class EventFormModel
    {
        [Required]
        public DateTime? Start { get; set; }

        [Required]
        public DateTime? End { get; set; }

        public bool Active { get; set; } = true;

        public CourseDetailsViewModel? Course { get; set; }

        [Required]
        [DisplayName("Teacher")]
        public string TeacherId { get; set; } = null!;

        public IEnumerable<UserSelectViewModel> Teachers { get; set; } = new HashSet<UserSelectViewModel>();
    }
}
