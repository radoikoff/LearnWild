using LearnWild.Services.Interfaces;
using LearnWild.Web.Infrastructure.Extensions;
using LearnWild.Web.ViewModels.Course;
using LearnWild.Web.ViewModels.Registration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static LearnWild.Common.NotificationMessagesConstants;
using static LearnWild.Common.GeneralApplicationConstants.PolicyNames;



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
                FirstName = User.GetFirstName(),
                LastName = User.GetLastName(),
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

                model.FirstName = User.GetFirstName();
                model.LastName = User.GetLastName();
                model.CourseTitle = courseModel!.Title;
                model.CourseStart = courseModel!.Start;
                model.CourseEnd = courseModel!.End;

                return View(model);
            }

            await _registrationService.RegisterAsync(model.StudentId, model.CourseId);

            TempData[SuccessMessage] = "You have been successfuly enrolled!";
            return RedirectToAction(nameof(Mine));
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            IEnumerable<RegistrationsViewModel> model = await _registrationService.GetRegistrationsByStudentIdAsync(User.GetId());
            return View(model);
        }

        [HttpGet]
        [Authorize(Policy = TeacherOrAdmin)]
        public async Task<IActionResult> Manage(string id)
        {
            if (!await _courseService.ExistsAsync(id))
            {
                return NotFound("Such course cannot be found!");
            }

            var model = await _courseService.GetAllStudentsWithScoresAsync(id);

            return View(model);
        }

        [HttpGet]
        [Authorize(Policy = TeacherOrAdmin)]
        public async Task<IActionResult> EditScore(string courseId, string studentId)
        {
            if (!await _courseService.ExistsAsync(courseId))
            {
                TempData[ErrorMessage] = "Such course cannot be found!";
                return RedirectToAction("All", "Course");
            }

            if (!await _registrationService.IsUserEnrolledAsync(studentId, courseId))
            {
                TempData[ErrorMessage] = "This student is not enrolled for this course!";
                return RedirectToAction(nameof(Manage), "Registration", new { id = courseId });
            }

            var model = await _registrationService.GetStudentScoresAsync(studentId, courseId);

            return View(model);
        }

        [HttpPost]
        [Authorize(Policy = TeacherOrAdmin)]
        public async Task<IActionResult> EditScore(StudentScoreFormModel model)
        {
            if (!await _courseService.ExistsAsync(model.CourseId))
            {
                ModelState.AddModelError(string.Empty, "Such course cannot be found!");
            }

            if (!await _registrationService.IsUserEnrolledAsync(model.StudentId, model.CourseId))
            {
                ModelState.AddModelError(string.Empty, "This student is not enrolled for this course!");
            }

            if (!ModelState.IsValid)
            {
                var course = await _courseService.GetByIdAsync(model.CourseId);
                model.CourseTitle = await _courseService.GetCourseTitleAsync(model.CourseId);
                model.StudentFullName = await _userService.GetUserFullNameAsync(model.StudentId);
                return View(model);
            }

            await _registrationService.EditStudentScoreAsync(model.StudentId, model.CourseId, model.Score, model.Credits);

            TempData[SuccessMessage] = "Student marks successfuly updated!";
            return RedirectToAction(nameof(Manage), "Registration", new { id = model.CourseId });
        }

        [HttpPost]
        [Authorize(Policy = TeacherOrAdmin)]
        public async Task<IActionResult> Remove(string courseId, string studentId)
        {
            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = ModelState.Values.SelectMany(v => string.Join(",", v.Errors));
            }

            if (!await _courseService.ExistsAsync(courseId))
            {
                TempData[ErrorMessage] = "Such course cannot be found!";
                return RedirectToAction(nameof(Manage), "Registration", new { id = courseId });
            }

            if (!await _registrationService.IsUserEnrolledAsync(studentId, courseId))
            {
                TempData[ErrorMessage] = "This student is not enrolled for this course!";
                return RedirectToAction(nameof(Manage), "Registration", new { id = courseId });
            }

            await _registrationService.RemoveStudentFromCourseAsync(studentId, courseId);

            TempData[SuccessMessage] = "Student successfuly removed!";
            return RedirectToAction(nameof(Manage), "Registration", new { id = courseId });
        }

    }
}
