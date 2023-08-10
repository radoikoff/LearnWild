using LearnWild.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;

namespace LearnWild.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            return RedirectToAction("All", "Course");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int id)
        {
            if (id == StatusCodes.Status400BadRequest || id == StatusCodes.Status404NotFound)
            {
                return View("Error404");
            }

            if (id == StatusCodes.Status401Unauthorized)
            {
                return View("Error401");
            }

            return View();
        }
    }
}