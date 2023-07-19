using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnWild.Web.ViewModels.Course
{
    public class EnrolToCourseFormModel : IValidatableObject
    {
        [Required]
        public string CourseId { get; set; } = null!;

        [Required]
        public string StudentId { get; set; } = null!;

        public string? CourseTitle { get; set; } = null!;

        [DisplayName("First Name")]
        public string? FirstName { get; set; } = null!;

        [DisplayName("Last Name")]
        public string? LastName { get; set; } = null!;

        [DisplayName("Accept General Conditions")]
        public bool AcceptGeneralConditions { get; set; }

        public string? CourseStart { get; set; } = null!;

        public string? CourseEnd { get; set; } = null!;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(AcceptGeneralConditions == false)
            {
                yield return new ValidationResult("You have to accept the General Conditions!", new[] {string.Empty});
            }
        }
    }
}
