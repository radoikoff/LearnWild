using LearnWild.Data.Models;
using LearnWild.Web.ViewModels.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LearnWild.Web.Controllers
{
    public class UserController : Controller
    {

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Login(string? returnUrl = null)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            var model = new LoginFormModel()
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userCandidate = await _userManager.FindByEmailAsync(model.Email);
            if (userCandidate == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid user name or password!");
                return View(model);
            }

            var result = await _signInManager.CheckPasswordSignInAsync(userCandidate, model.Password, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Invalid user name or password!");
                return View(model);
            }

            var customClaims = new[] { new Claim(ClaimTypes.GivenName, userCandidate.FirstName ?? string.Empty) };

            await _signInManager.SignInWithClaimsAsync(userCandidate, true, customClaims);

            return LocalRedirect(model.ReturnUrl ?? "/Course/All");
        }

        [HttpGet]
        public IActionResult Register(string? returnUrl = null)
        {
            var model = new RegisterFormModel()
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new ApplicationUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            await _userManager.SetEmailAsync(user, model.Email);
            await _userManager.SetUserNameAsync(user, model.Email);

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(model);
            }

            var customClaims = new[] { new Claim(ClaimTypes.GivenName, user.FirstName) };

            await _signInManager.SignInWithClaimsAsync(user, true, customClaims);
            return LocalRedirect(model.ReturnUrl ?? "/Course/All");
        }
    }
}

