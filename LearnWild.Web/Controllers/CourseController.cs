using LearnWild.Services.Interfaces;
using LearnWild.Web.ViewModels.Course;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearnWild.Web.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        private ICategoryService _categoryService;
        private ITypeService _typeService;

        public CourseController(ICategoryService categoryService, ITypeService typeService)
        {
            _categoryService = categoryService;
            _typeService = typeService;
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


    }
}
