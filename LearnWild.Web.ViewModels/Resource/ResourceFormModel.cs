using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

using static LearnWild.Common.EntityValidationConstants.Resource;

namespace LearnWild.Web.ViewModels.Resource
{
	public class ResourceFormModel : IValidatableObject
	{
		[Required]
		public string TopicId { get; set; } = null!;

		[Required]
		[StringLength(DisplayNameMaxLength, MinimumLength = DisplayNameMinLength)]
		[Display(Name = "Resource Name")]
		public string DisplayName { get; set; } = null!;

		[Display(Name = "File")]
		public IFormFile? FormFile { get; set; }

		[Url]
		[StringLength(UrlMaxLength, MinimumLength = UrlMinLength)]
		public string? Url { get; set; }

		public string TopicTitle { get; set; } = null!;

		public string CourseId { get; set; } = null!;

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (FormFile == null && Url == null)
			{
				yield return new ValidationResult("You have to provide either a File or an URL!", new[] { string.Empty });
			}

			if (FormFile != null && Url != null)
			{
				yield return new ValidationResult("You cannot provide File and URL together!", new[] { string.Empty });
			}
		}
	}
}
