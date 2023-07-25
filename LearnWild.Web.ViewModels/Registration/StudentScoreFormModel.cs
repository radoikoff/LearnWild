using System.ComponentModel.DataAnnotations;
using static LearnWild.Common.EntityValidationConstants.CourseRegistration;
using static LearnWild.Common.EntityValidationConstants.Course;

namespace LearnWild.Web.ViewModels.Registration
{
    public class StudentScoreFormModel : IValidatableObject
    {
        [Required]
        public string StudentId { get; set; } = null!;

        [Required]
        public string CourseId { get; set; } = null!;

        public string CourseTitle { get; set; } = null!;

        public string StudentFullName { get; set; } = null!;

        public int CourseMaxCredits { get; set; }

        public int? Credits { get; set; }

        public decimal? Score { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if ((Score.HasValue && Score < MinScore) || (Score.HasValue && Score > MaxScore))
            {
                yield return new ValidationResult($"Score must be between {MinScore} and {MaxScore}!", new[] { nameof(Score) });
            }

            if ((Credits.HasValue && Credits < MinCredit) || (Credits.HasValue && Credits > Math.Min(this.CourseMaxCredits, MaxCredit)))
            {
                yield return new ValidationResult($"Credit must be between {MinCredit} and {Math.Min(this.CourseMaxCredits, MaxCredit)}!", new[] { nameof(Credits) });
            }
        }
    }
}
