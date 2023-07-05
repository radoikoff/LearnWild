using System.ComponentModel.DataAnnotations;
using static LearnWild.Common.EntityValidationConstants.Topic;


namespace LearnWild.Data.Models
{
    public class Topic
    {
        public Topic()
        {
            this.Resources = new HashSet<Resource>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        public ICollection<Resource> Resources { get; set; } 
    }
}