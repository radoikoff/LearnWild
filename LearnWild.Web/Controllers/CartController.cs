using LearnWild.Services;
using LearnWild.Services.Interfaces;
using LearnWild.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static LearnWild.Common.NotificationMessagesConstants;

namespace LearnWild.Web.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICourceService _courseService;
        private readonly IOrderService _orderService;

        public CartController(ICourceService courseService, IOrderService orderService)
        {
            _courseService = courseService;
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _orderService.GetByUserIdAsync(User.GetId());
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(string courseId)
        {
            string userId = User.GetId();

            if (!await _courseService.ExistsAsync(courseId))
            {
                TempData[ErrorMessage] = "Provided course does not exists!";
                return RedirectToAction("All", "Course");
            }

            if (!await _courseService.IsActiveAsync(courseId))
            {
                TempData[ErrorMessage] = "You cannot register for inactive course!";
                return RedirectToAction("All", "Course");
            }

            if (await _orderService.HasOrderAsync(courseId, userId))
            {
                TempData[ErrorMessage] = "You have alredy paid for this course!";
                return RedirectToAction("All", "Course");
            }

            var teacher = await _courseService.GetTeacherAsync(courseId);
            if (teacher.Id == User.GetId())
            {
                TempData[ErrorMessage] = "You cannot register for your own course!";
                return RedirectToAction("All", "Course");
            }

            await _orderService.AddToOrderAsync(courseId, userId);
            
            TempData[SuccessMessage] = "Course successfuly added.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromOrderAsync(string orderId, string courseId)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> PayAsync(string orderId)
        {
            throw new NotImplementedException();
        }
    }
}
