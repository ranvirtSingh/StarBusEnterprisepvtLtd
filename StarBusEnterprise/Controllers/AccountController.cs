using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarBusEnterprise.FormViewModel;
using StarBusEnterprise.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;


namespace StarBusEnterprise.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInMAnager;
        private readonly ILogger<IdentityUser> logger;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInMAnager, ILogger<IdentityUser> logger)
        {
            this.userManager = userManager;

            this.signInMAnager = signInMAnager;
            this.logger = logger;
        }



        //private async Task LoadAsync(ApplicationUser user)
        //{
        //    var userName = await userManager.GetUserNameAsync(user);
          

        //    Username = userName;
        //}

            public IActionResult Index()
        {
            //RegisterViewModel model = new RegisterViewModel();
            return View();
        }

        public IActionResult Resgister()
        {
            RegisterViewModel model = new RegisterViewModel();
            return View(model);
        }
        public IActionResult Create()
        {
            RegisterViewModel model = new RegisterViewModel();
            return View(model);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.UserName, Email = model.Email  };
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await signInMAnager.SignInAsync(user, isPersistent: false);
                    //return RedirectToAction("Index", "home");
                    return Json("1");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }

            return View(model);
        }

        public IActionResult Login()
        {
            LoginViewModel model = new LoginViewModel();
            return View(@"~/Views/Account/Login.cshtml", model);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]

        
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                //var user = new ApplicationUser { Email = model.Email};
                //var user = new ApplicationUser { Email = model.Email };
                var result = await signInMAnager.PasswordSignInAsync(model.Email, model.Password, model.rememberme, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    logger.LogInformation("User logged in.");
                    return RedirectToAction("Index", "home");

                }

              
                
                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                

            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInMAnager.SignOutAsync();
            logger.LogInformation("User logged out.");
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }







    }
}