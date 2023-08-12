using LearnWild.Services.Interfaces;
using LearnWild.Web.ViewModels.Resource;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static LearnWild.Common.NotificationMessagesConstants;
using static LearnWild.Common.GeneralApplicationConstants.PolicyNames;
using LearnWild.Web.Infrastructure.Extensions;

namespace LearnWild.Web.Controllers
{
    [Authorize(Policy = TeacherOrAdmin)]
    public class ResourceController : Controller
    {
        private readonly IResourceService _resourceService;
        private readonly ITopicService _topicService;

        public ResourceController(IResourceService resourceService, ITopicService topicService)
        {
            _resourceService = resourceService;
            _topicService = topicService;
        }


        [HttpGet]
        public async Task<IActionResult> Create(string topicId)
        {
            var topic = await _topicService.GetByIdForEditAsync(topicId);

            if (topic == null)
            {
                TempData[ErrorMessage] = "No such topic found!";
            }

            var model = new ResourceFormModel()
            {
                TopicId = topicId,
                TopicTitle = topic?.Title ?? string.Empty,
                CourseId = topic?.CourseId ?? string.Empty,
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ResourceFormModel model)
        {
            if (!await _topicService.ExistsAsync(model.TopicId))
            {
                ModelState.AddModelError(string.Empty, "Such topic cannot be found!");
            }

            var teacher = await _topicService.GetTeacherByTopicIdAsync(model.TopicId);
            var teacherId = teacher?.Id ?? string.Empty;

            if (!((teacherId == User.GetId()) || User.IsAdmin()))
            {
                ModelState.AddModelError(string.Empty, "Only course teacher can add resources!");
            }

            if (await _resourceService.ExistsAsync(model.TopicId, model.DisplayName))
            {
                ModelState.AddModelError(string.Empty, "Resource with same name already exists!");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            bool succeeded = await _resourceService.CreateResourseAsync(model);

            if (!succeeded)
            {
                TempData[ErrorMessage] = "Fail to create resourse!";
                return View(model);
            }

            TempData[SuccessMessage] = "Resource successfuly created.";
            return RedirectToAction("All", "Topic", new { courseId = model.CourseId });
        }

        [HttpGet]
        public async Task<IActionResult> Download(string id, string returnUrl)
        {
            if (!await _resourceService.ExistsAsync(id))
            {
                TempData[ErrorMessage] = "No such topic found!";
                return Redirect(returnUrl);
            }

            var fileInfo = await _resourceService.GetResourseFileInfo(id);

            if (fileInfo == null)
            {
                TempData[ErrorMessage] = "The resourse is not downloadable!";
                return Redirect(returnUrl);
            }


            return File(fileInfo.ReadStream, fileInfo.MimeType, fileInfo.FileName);
        }

    }
}
