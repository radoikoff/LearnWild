using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static LearnWild.Common.EntityValidationConstants.ApplicationUser;

namespace LearnWild.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Registrations = new HashSet<CourseRegistration>();
            this.TeachingCourses = new HashSet<Course>();
            this.CreatedCourses = new HashSet<Course>();
        }

        [MaxLength(FirstNameMaxLength)]
        public string? FirstName { get; set; }
        
        [MaxLength(LastNameMaxLength)]
        public string? LastName { get; set; }

        public ICollection<CourseRegistration> Registrations { get; set; }
        public ICollection<Course> TeachingCourses { get; set; }
        public ICollection<Course> CreatedCourses { get; set; }
    }
}