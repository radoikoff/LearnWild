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

        public IActionResult Add() => RedirectToAction("All", "Course"); //In case user is not logged ant try to access POST ADD.

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

            var teacher = await _courseService.GetTeacherAsync(courseId);
            if (teacher.Id == User.GetId())
            {
                TempData[ErrorMessage] = "You cannot register for your own course!";
                return RedirectToAction("All", "Course");
            }

            if (await _orderService.IsActiveOrderContainsCourseAsync(courseId, userId))
            {
                TempData[ErrorMessage] = "You have alredy added this course in the cart!";
                return RedirectToAction("All", "Course");
            }

            if (await _orderService.IsOrderContainsCourseAsync(courseId, userId))
            {
                TempData[ErrorMessage] = "You are already enrolled for that course!";
                return RedirectToAction("All", "Course");
            }

            await _orderService.AddCourseToActiveOrderAsync(courseId, userId);
            
            TempData[SuccessMessage] = "Course successfuly added.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Remove(string courseId)
        {
            string userId = User.GetId();

            if (!await _orderService.IsActiveOrderExistsAsync(userId))
            {
                TempData[ErrorMessage] = "Such order does not exist or you are not its creator!";
                return RedirectToAction(nameof(Index));
            }

            if (!await _orderService.IsActiveOrderContainsCourseAsync(courseId, userId))
                
            {
                TempData[ErrorMessage] = "This course is not in your cart!";
                return RedirectToAction(nameof(Index));
            }

            await _orderService.RemoveFromActiveOrderAsync(courseId, userId);

            TempData[SuccessMessage] = "Course successfuly removed.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(string orderId)
        {
            if (!await _orderService.IsActiveOrderExistsAsync(orderId, User.GetId()))
            {
                TempData[ErrorMessage] = "Such order does not exist or you are not its creator!";
                return RedirectToAction("All", "Course");
            }

            await _orderService.CheckoutAsync(orderId);
            TempData[SuccessMessage] = "Payment successful!";
            return RedirectToAction("All", "Course");
        }
    }
}
