using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static LearnWild.Common.EntityValidationConstants.ApplicationUser;

namespace LearnWild.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Registrations = new HashSet<EventRegistration>();
            this.TrainingEvents = new HashSet<TrainingEvent>();
            this.CreatedCourses = new HashSet<Course>();
        }

        [MaxLength(FirstNameMaxLength)]
        public string? FirstName { get; set; }
        
        [MaxLength(LastNameMaxLength)]
        public string? LastName { get; set; }

        public ICollection<EventRegistration> Registrations { get; set; }
        public ICollection<TrainingEvent> TrainingEvents { get; set; }
        public ICollection<Course> CreatedCourses { get; set; }
    }
}