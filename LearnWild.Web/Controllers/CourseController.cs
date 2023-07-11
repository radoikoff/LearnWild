using LearnWild.Services.Interfaces;
using LearnWild.Web.ViewModels.Course;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LearnWild.Web.Infrastructure.Extensions;

namespace LearnWild.Web.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ITypeService _typeService;
        private readonly ICourceService _courseService;

        public CourseController(ICategoryService categoryService, ITypeService typeService, ICourceService courseService)
        {
            _categoryService = categoryService;
            _typeService = typeService;
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new CourseFormModel()
            {
                Categories = await _categoryService.AllCategoriesAsync(),
                Types = await _typeService.AllTypesAsync(),
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseFormModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                inputModel.Categories = await _categoryService.AllCategoriesAsync();
                inputModel.Types = await _typeService.AllTypesAsync();
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
    }
}
