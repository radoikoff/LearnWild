using Microsoft.AspNetCore.Identity;

namespace LearnWild.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Registrations = new HashSet<EventRegistration>();
        }
        public ICollection<EventRegistration> Registrations { get; set; }
    }
}