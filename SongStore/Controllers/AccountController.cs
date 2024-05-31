using SongStore.Models;
using SongStore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SongStore.Controllers
{
    public class AccountController : Controller
    {
        #region ctor
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration config;
        private readonly IWebHostEnvironment environment;
        public AccountController(SignInManager<ApplicationUser> _signInManager, UserManager<ApplicationUser> _userManager
            , IConfiguration _configuration, IWebHostEnvironment _env)
        {
            this.signInManager = _signInManager;
            this.userManager = _userManager;
            this.config = _configuration;
            this.environment = _env;
        }
        #endregion

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string ReturnUrl)
        {
            LoginViewModel model = new LoginViewModel
            {
                ReturnUrl = ReturnUrl
            };

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string ReturnUrl)
        {
            model.ReturnUrl = ReturnUrl;

            if (ModelState.IsValid)
            {
                ApplicationUser user = await userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, true);

                    if (result.Succeeded)
                    {
                        if (!string.IsNullOrEmpty(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
                        {
                            ViewBag.JavaScriptFunction = $"window.location.replace('{ReturnUrl}');";
                            return View(model);
                        }
                        else
                        {
                            ViewBag.JavaScriptFunction = $"window.location.replace('{Url.Action("Index", "Home")}');";
                            return View(model);
                        }
                    }

                    if (result.IsLockedOut)
                    {
                        ModelState.AddModelError(string.Empty, "Account Locked");
                    }
                    if (result.IsNotAllowed)
                    {
                        ModelState.AddModelError(string.Empty, "Login Not Allowed");
                    }

                    //invalid password or couldn't signin the user
                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                }
                else
                {
                    //user not found with email
                    ModelState.AddModelError(string.Empty, "User not found");
                }

            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await signInManager.SignOutAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction("Login", "Account");
        }

    }
}

