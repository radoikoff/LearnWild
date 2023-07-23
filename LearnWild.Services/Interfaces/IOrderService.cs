using LearnWild.Web.ViewModels.Order;
namespace LearnWild.Services.Interfaces
{
	public interface IOrderService
	{
		Task<bool> IsActiveOrderContainsCourseAsync(string courseId, string userId);
		Task<bool> IsOrderContainsCourseAsync(string courseId, string userId);
		Task AddCourseToActiveOrderAsync(string courseId, string userId);
		Task<OrderViewModel> GetByUserIdAsync(string userId);
		Task CheckoutAsync(string orderId);
		Task<bool> IsActiveOrderExistsAsync(string orderId, string userId);
		Task<bool> IsActiveOrderExistsAsync(string userId);
		Task RemoveFromActiveOrderAsync(string courseId, string userId);
	}
}
