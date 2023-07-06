using System.ComponentModel.DataAnnotations;
using static LearnWild.Common.EntityValidationConstants.Topic;


namespace LearnWild.Data.Models
{
    public class Topic
    {
        public Topic()
        {
            this.Id = Guid.NewGuid();
            this.Resources = new HashSet<Resource>();
        }

        [Key]
        public Guid Id { get; set; }

        public Guid CourseId { get; set; }
        public Course Course { get; set; } = null!;

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        public ICollection<Resource> Resources { get; set; } 
    }
}