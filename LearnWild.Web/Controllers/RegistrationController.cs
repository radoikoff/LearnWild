using LearnWild.Services.Interfaces;
using LearnWild.Web.Infrastructure.Extensions;
using LearnWild.Web.ViewModels.Course;
using LearnWild.Web.ViewModels.Registration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace LearnWild.Web.Controllers
{
    [Authorize]
    public class RegistrationController : Controller
    {
        private readonly IRegistrationService _registrationService;
        private readonly IUserService _userService;
        private readonly ICourceService _courseService;

        public RegistrationController(
            IRegistrationService registrationService,
            IUserService userService,
            ICourceService courseService)
        {
            _registrationService = registrationService;
            _userService = userService;
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> Apply(string id)
        {
            if (!await _courseService.ExistsAsync(id))
            {
                return NotFound("Such course cannot be found");
            }

            CourseDetailsViewModel? courseModel = await _courseService.GetByIdAsync(id);

            var viewModel = new EnrolToCourseFormModel()
            {
                CourseId = id,
                StudentId = User.GetId(),
                FirstName = "Petar", //TODO: Add real user here
                LastName = "Petrov",
                CourseTitle = courseModel!.Title,
                CourseStart = courseModel!.Start,
                CourseEnd = courseModel!.End
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Apply(EnrolToCourseFormModel model)
        {
            if (!await _courseService.ExistsAsync(model.CourseId))
            {
                ModelState.AddModelError(string.Empty, "Such course does not exists!");
            }

            if (!await _courseService.IsActiveAsync(model.CourseId))
            {
                ModelState.AddModelError(string.Empty, "You cannot enroll to inactive course");
            }

            if (model.StudentId != User.GetId())
            {
                ModelState.AddModelError(string.Empty, "You cannot apply on behalf of other person!");
            }

            if (await _registrationService.IsUserEnrolledAsync(model.StudentId, model.CourseId))
            {
                ModelState.AddModelError(string.Empty, "You are already enrolled for the course!");
            }

            var teacher = await _courseService.GetTeacherAsync(model.CourseId);
            if (model.StudentId == teacher.Id)
            {
                ModelState.AddModelError(string.Empty, "You cannot enrole for your own course!");
            }

            if (!ModelState.IsValid)
            {
                var courseModel = await _courseService.GetByIdAsync(model.CourseId);

                model.FirstName = "Petar"; //TODO: Add real user here
                model.LastName = "Petrov";
                model.CourseTitle = courseModel!.Title;
                model.CourseStart = courseModel!.Start;
                model.CourseEnd = courseModel!.End;

                return View(model);
            }

            await _registrationService.RegisterAsync(model.StudentId, model.CourseId);

            //TODO: Raise success notification
            return RedirectToAction(nameof(Mine));
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            IEnumerable<RegistrationsViewModel> model = await _registrationService.GetRegistrationsByStudentIdAsync(User.GetId());
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Manage(string id)
        {
            if (!await _courseService.ExistsAsync(id))
            {
                return NotFound("Such course cannot be found!");
            }

            var model = await _courseService.GetStudentScoresAsync(id);

            return View(model);
        }

    }
}
