using LearnWild.Data.Models;
using LearnWild.Services;
using LearnWild.Services.Interfaces;
using LearnWild.Web.Infrastructure.Extensions;
using LearnWild.Web.ViewModels;
using LearnWild.Web.ViewModels.Quiz;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static LearnWild.Common.NotificationMessagesConstants;

namespace LearnWild.Web.Areas.Quiz.Controllers
{
    [Area("Quiz")]
    [Authorize]
    public class QuizController : Controller
    {

        private readonly IQuizService _quizService;
        private readonly IRegistrationService _registrationService;

        public QuizController(IQuizService quizService, IRegistrationService registrationService)
        {
            _quizService = quizService;
            _registrationService = registrationService;
        }

        [HttpGet]
        public async Task<IActionResult> Start(string id, string courseId)
        {
            if (!await _quizService.ExistsAsync(id))
            {
                TempData[ErrorMessage] = "Quiz does not exists!";
                return RedirectToAction("Details", "Course", new { Id = courseId, Area = string.Empty });
            }

            if (!await _registrationService.IsUserEnrolledAsync(User.GetId(), courseId))
            {
                TempData[ErrorMessage] = "You are not student in this course!";
                return RedirectToAction("Details", "Course", new { Id = courseId, Area = string.Empty });
            }

            var attempt = await _quizService.GetAttemptAsync(id, User.GetId());
            if (attempt == null)
            {
                attempt = await _quizService.CreateAttemptAsync(id, User.GetId());
            }

            if (attempt.Active == false)
            {
                TempData[ErrorMessage] = "You already finished that quiz!";
                return RedirectToAction("Details", "Course", new { Id = courseId, Area = string.Empty });
            }

            return RedirectToAction("Step", "Quiz", new { Id = attempt.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Step(string questionId)
        {
            if (!await _quizService.QuestionExistsAsync(questionId))
            {
                return BadRequest();
            }

            //if (!await _quizService.HasStudentAccessToQuestionAsync(questionId, User.GetId()))
            //{
            //    BadRequest();
            //}

            var model = await _quizService.GetQuizStepAsync(questionId, User.GetId());
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Step(string questionId, string responseId)
        {
            try
            {
                await _quizService.SaveStepAsync(questionId, responseId);
                TempData[SuccessMessage] = "Saved";
                var model = await _quizService.GetQuizStepAsync(questionId, User.GetId());
                return View(model);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Someting was wrong! Please try again!";
                var model = await _quizService.GetQuizStepAsync(questionId, User.GetId());
                return View(model);
            }
        }




    }
}
