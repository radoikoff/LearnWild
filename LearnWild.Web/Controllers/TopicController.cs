using LearnWild.Services.Interfaces;
using LearnWild.Web.ViewModels.Topic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static LearnWild.Common.NotificationMessagesConstants;
using static LearnWild.Common.GeneralApplicationConstants.PolicyNames;


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
        public IActionResult Index(string id) => RedirectToAction(nameof(All), id);

        [HttpGet]
        public async Task<IActionResult> All(string id)
        {
            ViewBag.CourseId = id;
            var topics = await _topicService.GetAllTopicsForCourseAsync(id);
            return View(topics);
        }

        [HttpGet]
        public IActionResult Create(string id)
        {
            var model = new TopicFormModel()
            {
                CourseId = id
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
            return RedirectToAction(nameof(All), new { id = model.CourseId });
        }
    }
}
