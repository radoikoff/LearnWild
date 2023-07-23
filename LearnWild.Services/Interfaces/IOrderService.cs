using LearnWild.Web.ViewModels.Order;
namespace LearnWild.Services.Interfaces
{
	public interface IOrderService
	{
		Task<bool> HasOrderAsync(string courseId, string userId);
		Task AddToOrderAsync(string courseId, string userId);
		Task<OrderViewModel> GetByUserIdAsync(string userId);
	}
}
