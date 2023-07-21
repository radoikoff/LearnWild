using LearnWild.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LearnWild.Data.Models
{
	public class Order
	{
		public Order()
		{
			Registrations = new HashSet<CourseRegistration>();
		}

		[Key]
		public Guid Id { get; set; }

		public Guid UserId { get; set; }
		public ApplicationUser User { get; set; } = null!;

		public ICollection<CourseRegistration> Registrations { get; set; }

		public OrderStatus Status { get; set; }

		public DateTime CreatedOn { get; set; }

		public DateTime CompletedOn { get; set; }

		[Precision(18,4)]
		public decimal? PricePaid { get; set; }
	}
}