using LearnWild.Services.Interfaces;
using LearnWild.Web.ViewModels.Topic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static LearnWild.Common.NotificationMessagesConstants;
using static LearnWild.Common.GeneralApplicationConstants.PolicyNames;
using LearnWild.Services;


namespace LearnWild.Web.Controllers
{
    [Authorize(Policy = TeacherOrAdmin)]
    public class TopicController : Controller
    {
        private readonly ITopicService _topicService;
        private readonly ICourceService _courseService;

        public TopicController(ITopicService topicService, ICourceService courseService)
        {
            _topicService = topicService;
            _courseService = courseService;
        }

        [HttpGet]
        public IActionResult Index(string courseId) => RedirectToAction(nameof(All), courseId);

        [HttpGet]
        public async Task<IActionResult> All(string courseId)
        {
            ViewBag.CourseId = courseId;
            var topics = await _topicService.GetAllTopicsForCourseAsync(courseId);
            return View(topics);
        }

        [HttpGet]
        public IActionResult Create(string courseId)
        {
            var model = new TopicFormModel()
            {
                CourseId = courseId
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TopicFormModel model)
        {
            if (!await _courseService.ExistsAsync(model.CourseId))
            {
                ModelState.AddModelError(string.Empty, "Such course does not exists!");
            }

            if (await _topicService.ExistsAsync(model.CourseId, model.Title))
            {
                ModelState.AddModelError(nameof(model.Title), "Topic with the same title already exisits!");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _topicService.CreateTopicAsync(model);

            TempData[SuccessMessage] = "Successfuly created topic!";
            return RedirectToAction(nameof(All), new { courseId = model.CourseId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (!await _topicService.ExistsAsync(id))
            {
                return NotFound("Such topic cannot be found");
            }

            var model = await _topicService.GetByIdForEditAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TopicFormModel inputModel, string id)
        {
            if (!await _topicService.ExistsAsync(id))
            {
                return NotFound("Such topic cannot be found");
            }

            if (await _topicService.ExistsAsync(inputModel.CourseId, inputModel.Title, id))
            {
                ModelState.AddModelError(nameof(inputModel.Title), "Topic with the same title already exisits!");
            }

            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }

            await _topicService.EditTopicAsync(inputModel, id);

            TempData[SuccessMessage] = "Successfuly edited topic!";
            return RedirectToAction(nameof(All), new { courseId = inputModel.CourseId });
        }


    }
}
