using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnWild.Data.Models
{
    public class TrainingEvent
    {
        public TrainingEvent()
        {
            this.Registrations = new List<EventRegistration>();
        }

        public int Id { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public bool Active { get; set; }

        public Guid TeacherId { get; set; }
        public ApplicationUser Teacher { get; set; } = null!;

        public ICollection<EventRegistration> Registrations { get; set; } 
    }
}
