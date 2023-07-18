using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static LearnWild.Common.EntityValidationConstants.Course;

namespace LearnWild.Web.ViewModels.Course
{
    public class CourseFormModel
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

        [Range(MinDuration, MaxDuration)]
        [DisplayName("Duration in hours")]
        public int Duration { get; set; }

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

        //public Guid? DefaultTeacherId { get; set; }

        public IEnumerable<OptionsViewModel> Categories { get; set; } = new HashSet<OptionsViewModel>();
        public IEnumerable<OptionsViewModel> Types { get; set; } = new HashSet<OptionsViewModel>();
    }
}
