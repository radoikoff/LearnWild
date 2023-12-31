﻿using LearnWild.Services.Interfaces;
using LearnWild.Web.ViewModels.Course;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LearnWild.Web.Infrastructure.Extensions;
using LearnWild.Web.ViewModels.Event;
using static LearnWild.Common.GeneralApplicationConstants.PolicyNames;
using static LearnWild.Common.NotificationMessagesConstants;

namespace LearnWild.Web.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ITypeService _typeService;
        private readonly ICourceService _courseService;
        private readonly IUserService _userService;

        public CourseController(
            ICategoryService categoryService,
            ITypeService typeService,
            ICourceService courseService,
            IUserService userService)
        {
            _categoryService = categoryService;
            _typeService = typeService;
            _courseService = courseService;
            _userService = userService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index() => RedirectToAction(nameof(All));


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All(CourseSearchModel model)
        {
            model.Courses = await _courseService.GetAllAsync(model);
            model.Categories = await _categoryService.AllCategoriesAsync();
            model.Types = await _typeService.AllTypesAsync();

            foreach (var category in model.Categories)
            {
                category.Selected = model.SelectedCategories?.Contains(category.Id) ?? false;
            }

            foreach (var type in model.Types)
            {
                type.Selected = model.SelectedTypes?.Contains(type.Id) ?? false;
            }


            return View(model);
        }

        [HttpGet]
        [Authorize(Policy = TeacherOrAdmin)]
        public async Task<IActionResult> Create()
        {
            var model = new CourseFormModel()
            {
                Categories = await _categoryService.AllCategoriesAsync(),
                Types = await _typeService.AllTypesAsync(),
                Teachers = await _userService.GetTeachersAsync()
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Policy = TeacherOrAdmin)]
        public async Task<IActionResult> Create(CourseFormModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                inputModel.Categories = await _categoryService.AllCategoriesAsync();
                inputModel.Types = await _typeService.AllTypesAsync();
                inputModel.Teachers = await _userService.GetTeachersAsync();

                return View(inputModel);
            }

            bool scheduled = await _courseService.IsScheduled(inputModel.Start, inputModel.End, inputModel.TeacherId);
            if (scheduled)
            {
                ModelState.AddModelError(string.Empty, "There is conflict with another course!");
                inputModel.Categories = await _categoryService.AllCategoriesAsync();
                inputModel.Types = await _typeService.AllTypesAsync();
                inputModel.Teachers = await _userService.GetTeachersAsync();
                return View(inputModel);
            }

            string creatorId = User.GetId();

            await _courseService.CreateCourseAsync(inputModel, creatorId);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            bool exists = await _courseService.ExistsAsync(id);

            if (!exists)
            {
                return NotFound(id);
            }

            CourseDetailsViewModel? model = await _courseService.GetByIdAsync(id);

            return View(model);
        }

        [HttpGet]
        [Authorize(Policy = TeacherOrAdmin)]
        public async Task<IActionResult> Edit(string id)
        {
            if (!await _courseService.ExistsAsync(id))
            {
                return NotFound("Such course cannot be found");
            }

            CourseFormModel model = await _courseService.GetForEditByIdAsync(id);

            model.Categories = await _categoryService.AllCategoriesAsync();
            model.Types = await _typeService.AllTypesAsync();
            model.Teachers = await _userService.GetTeachersAsync();

            return View(model);
        }

        [HttpPost]
        [Authorize(Policy = TeacherOrAdmin)]
        public async Task<IActionResult> Edit(CourseFormModel inputModel, string id)
        {
            if (!await _courseService.ExistsAsync(id))
            {
                return NotFound("Such course cannot be found");
            }

            if (!ModelState.IsValid)
            {
                inputModel.Categories = await _categoryService.AllCategoriesAsync();
                inputModel.Types = await _typeService.AllTypesAsync();
                inputModel.Teachers = await _userService.GetTeachersAsync();
                return View(inputModel);
            }

            bool scheduled = await _courseService.IsScheduled(inputModel.Start, inputModel.End, inputModel.TeacherId, id);
            if (scheduled)
            {
                ModelState.AddModelError(string.Empty, "There is conflict with another course!");
                inputModel.Categories = await _categoryService.AllCategoriesAsync();
                inputModel.Types = await _typeService.AllTypesAsync();
                inputModel.Teachers = await _userService.GetTeachersAsync();
                return View(inputModel);
            }

            await _courseService.EditCourseAsync(inputModel, id);

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        public IActionResult Calendar() => View();


        [HttpGet("/api/courses")]
        public async Task<IActionResult> GetAllEventsForCalendar()
        {
            IEnumerable<EventCalendarViewModel> allEvents = await _courseService.GetCalendarData();

            return new JsonResult(allEvents);
        }

        [HttpGet]
        [Authorize(Policy = TeacherOrAdmin)]
        public async Task<IActionResult> Mine()
        {
            var teachingCourses = await _courseService.GetCoursesByTeacherIdAsync(User.GetId());
            return View(teachingCourses);
        }

    }
}
