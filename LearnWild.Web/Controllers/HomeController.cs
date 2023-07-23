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
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == StatusCodes.Status400BadRequest || statusCode == StatusCodes.Status404NotFound)
            {
                return View("Error404");
            }

            if (statusCode == StatusCodes.Status401Unauthorized)
            {
                return View("Error401");
            }

            return View();
        }
    }
}