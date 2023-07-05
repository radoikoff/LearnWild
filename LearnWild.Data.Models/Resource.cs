using LearnWild.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using static LearnWild.Common.EntityValidationConstants.Resource;

namespace LearnWild.Data.Models
{
    public class Resource
    {
        [Key]
        public int Id { get; set; }

        public int TopicId { get; set; }
        public Topic Topic { get; set; } = null!;

        [Required]
        [MaxLength(DisplayNameMaxLength)]
        public string DisplayName { get; set; } = null!;

        public ResourceType Type { get; set; }

        [MaxLength(UrlMaxLength)]
        public string? Url { get; set; }

        [MaxLength(FilePathMaxLength)]
        public string? FilePath { get; set; }

    }
}