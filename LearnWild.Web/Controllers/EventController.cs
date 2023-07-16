using LearnWild.Services.Interfaces;
using LearnWild.Web.ViewModels.Event;
using Microsoft.AspNetCore.Mvc;

namespace LearnWild.Web.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService _eventService;
        private readonly ICourceService _courseService;
        private readonly IUserService _userService;

        public EventController(IEventService eventService, ICourceService courseService, IUserService userService)
        {
            _eventService = eventService;
            _courseService = courseService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Create(string courseId)
        {
            if (!await _courseService.ExistsAsync(courseId))
            {
                return NotFound();
            }

            var model = new EventFormModel()
            {
                Course = await _courseService.GetByIdAsync(courseId),
                Teachers = await _userService.GetTeachersAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EventFormModel model, string courseId)
        {

            if (!ModelState.IsValid)
            {
                model.Course = await _courseService.GetByIdAsync(courseId);
                model.Teachers = await _userService.GetTeachersAsync();
                return View(model);
            }

            if (!await _courseService.ExistsAsync(courseId))
            {
                return NotFound();
            }

            bool scheduled = await _eventService.IsScheduled(model.Start, model.End, courseId, model.TeacherId);
            if (scheduled)
            {
                ModelState.AddModelError(string.Empty, "This course is already scheduled!");
                model.Course = await _courseService.GetByIdAsync(courseId);
                model.Teachers = await _userService.GetTeachersAsync();
                return View(model);
            }

            await _eventService.CreateAsync(model, courseId);
            //TODO: Success message
            return RedirectToAction("All");
        }
    }
}
