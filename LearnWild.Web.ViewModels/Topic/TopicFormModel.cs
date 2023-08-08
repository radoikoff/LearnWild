using System.ComponentModel.DataAnnotations;
using static LearnWild.Common.EntityValidationConstants.Topic;


namespace LearnWild.Web.ViewModels.Topic
{
    public class TopicFormModel
    {
        [Required]
        public string CourseId { get; set; } = null!;

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;
    }
}
