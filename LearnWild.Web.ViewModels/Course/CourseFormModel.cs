using LearnWild.Web.ViewModels.User;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static LearnWild.Common.EntityValidationConstants.Course;

namespace LearnWild.Web.ViewModels.Course
{
    public class CourseFormModel : IValidatableObject
    {
        [Required]
        [StringLength(TitleMaxLength, MinimumLength =TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        public DateTime? Start { get; set; }

        [Required]
        public DateTime? End { get; set; }

        public bool Active { get; set; } = true;

        [Range(MinCredit, MaxCredit)]
        public int Credits { get; set; }

        [Range(typeof(decimal), MinPrice, MaxPrice)]
        public decimal? Price { get; set; }

        [Range(0,int.MaxValue)]
        [DisplayName("Course Category")]
        public int CategoryId { get; set; }

        [Range(0, int.MaxValue)]
        [DisplayName("Course Type")]
        public int TypeId { get; set; }

        [Required]
        [DisplayName("Teacher")]
        public string TeacherId { get; set; } = null!;

        public IEnumerable<OptionsViewModel> Categories { get; set; } = new HashSet<OptionsViewModel>();
        public IEnumerable<OptionsViewModel> Types { get; set; } = new HashSet<OptionsViewModel>();
        public IEnumerable<UserSelectViewModel> Teachers { get; set; } = new HashSet<UserSelectViewModel>();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.End <= this.Start)
            {
                yield return new ValidationResult("End Date must be after Start date!", new[] { nameof(End) });
            }
        }
    }
}
