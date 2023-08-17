using System.ComponentModel.DataAnnotations;
using static LearnWild.Common.EntityValidationConstants.Question;

namespace LearnWild.Data.Models
{
    public class Question
    {
        [Key]
        public Guid Id { get; set; }

        public Guid QuizId { get; set; }
        public Quiz Quiz { get; set; } = null!;

        [Required]
        [MaxLength(TextMaxLength)]
        public string Text { get; set; } = null!;

        public int SequentialNumber { get; set; }

        public ICollection<Response> Responses { get; set; } = new HashSet<Response>();

        //public Guid CorrectResponse { get; set; }
    }
}
