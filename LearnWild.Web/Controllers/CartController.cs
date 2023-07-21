using LearnWild.Services;
using LearnWild.Services.Interfaces;
using LearnWild.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

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

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(string courseId)
        {
            string userId = User.GetId();

            if (!await _courseService.ExistsAsync(courseId))
            {
                //TODO: Course does not exists!
            }

            if (!await _courseService.IsActiveAsync(courseId))
            {
                //"You cannot register for inactive course!";
            }

            if (await _orderService.HasOrderAsync(courseId, userId))
            {
                //"You have alredy paid for this course!";
            }

            var teacher = await _courseService.GetTeacherAsync(courseId);
            if (teacher.Id == User.GetId())
            {
                //"You cannot register for your own course!"
            }

            await _orderService.AddToOrderAsync(courseId, userId);
            //Success message
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
