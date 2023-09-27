using CoreCMS.Model;
using CoreCMS.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreCMS.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<CustomUser> _userManager;
        private readonly SignInManager<CustomUser> _signInManager;

        public AccountController(UserManager<CustomUser> userManager, SignInManager<CustomUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {      
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(viewModel.UserName, viewModel.Password, false, true);

                if (result.Succeeded)
                {                     
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid Login Attempt");
                return View(viewModel);
            }

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                //check if user with an email already exists in the database
                var userExists = await _userManager.FindByEmailAsync(viewModel.Email);

                if(userExists == null)
                {
                    var user = new CustomUser
                    {
                        UserName = viewModel.UserName,
                        Email = viewModel.Email,
                        FirstName = viewModel.FirstName,
                        LastName = viewModel.LastName
                    };

                    //creating the user in the database
                    var result = await _userManager.CreateAsync(user, viewModel.Password);

                    //true
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index","Home");
                    }

                    ModelState.AddModelError("", "Could not create new user in the database");
                    return View(viewModel);
                }
            }

            return View(viewModel);
        }
    }

}
