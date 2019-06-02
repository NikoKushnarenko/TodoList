using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DAL.TodoList.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TodoList.ViewModels;

namespace TodoList.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> userMgr, SignInManager<AppUser> signinManager)
        {
            userManager = userMgr;
            _signInManager = signinManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationViewModel newPerson)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser { UserName = newPerson.Name, Email = newPerson.Email };
                IdentityResult res = await userManager.CreateAsync(user, newPerson.Password);
                if (res.Succeeded)
                {
                    RedirectToAction("Login");
                }
                else
                {
                    foreach(IdentityError error in res.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel userLogin)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await userManager.FindByEmailAsync(userLogin.Email);
                if(user!= null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, userLogin.Password, false, false);
                    if (result.Succeeded)
                    {
                        return Redirect("/");
                    }
                }
                ModelState.AddModelError("", "Invalid email or password");
            }
            return View();

        }
    }
}
