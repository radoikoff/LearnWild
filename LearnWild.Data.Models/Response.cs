using System.ComponentModel.DataAnnotations;
using static LearnWild.Common.EntityValidationConstants.Response;

namespace LearnWild.Data.Models
{
    public class Response
    {
        [Key]
        public Guid Id { get; set; }

        public Guid QuestionId { get; set; }
        public Question Question { get; set; } = null!;

        [Required]
        [MaxLength(TextMaxLength)]
        public string Text { get; set; } = null!;

        public bool IsCorrect { get; set; }

        public ICollection<StudentResponse> StudentResponses { get; set; } = new HashSet<StudentResponse>();
    }
}
