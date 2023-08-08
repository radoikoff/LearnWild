using LearnWild.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static LearnWild.Common.GeneralApplicationConstants.PolicyNames;


namespace LearnWild.Web.Controllers
{
    [Authorize(Policy = TeacherOrAdmin)]
    public class TopicController : Controller
    {
        private readonly ITopicService _topicService;

        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
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
        public Task<IActionResult> Add(string id)
        {

            return View();
        }
    }
}
