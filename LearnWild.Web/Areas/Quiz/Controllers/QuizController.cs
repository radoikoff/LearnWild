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

        public QuizController(IQuizService quizService)
        {
            _quizService = quizService;
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
