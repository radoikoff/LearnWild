using System.ComponentModel.DataAnnotations;
using static LearnWild.Common.EntityValidationConstants.CourseType;

namespace LearnWild.Data.Models
{
    public class CourseType
    {
        public CourseType()
        {
            this.Courses = new HashSet<Course>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Course> Courses { get; set; }
    }
}