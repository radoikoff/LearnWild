using LearnWild.Web.ViewModels.Course;
using LearnWild.Web.ViewModels.User;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace LearnWild.Web.ViewModels.Event
{
	public class EventFormModel : IValidatableObject
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


		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if(this.End <= this.Start)
            {
                yield return new ValidationResult("End Date must be after Start date!", new [] { nameof(End) });
            }
		}
	}
}
