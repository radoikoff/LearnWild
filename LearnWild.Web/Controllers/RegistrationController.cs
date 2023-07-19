using LearnWild.Services;
using LearnWild.Services.Interfaces;
using LearnWild.Web.Infrastructure.Extensions;
using LearnWild.Web.ViewModels.Course;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static LearnWild.Common.GeneralApplicationConstants.ApplicationRoles;


namespace LearnWild.Web.Controllers
{
    [Authorize(Roles = $"{TeacherRoleName},{AdminRoleName}")]
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

            if (model.StudentId != User.GetId())
            {
                ModelState.AddModelError(string.Empty, "You cannot apply on helaf of other person!");
            }

            if (await _registrationService.IsUserEnrolled(model.StudentId, model.CourseId))
            {
                ModelState.AddModelError(string.Empty, "You are already enrolled for the course!");
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

            await _registrationService.Register(model.StudentId, model.CourseId);

            //TODO: Raise success notification
            return RedirectToAction("Mine", "Course");
        }
    }
}
