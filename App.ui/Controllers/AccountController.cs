using App.ui.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
  
namespace App.ui.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _UserManger;
        private readonly SignInManager<IdentityUser> _SignInManger;
        private readonly RoleManager<IdentityRole> _RoleManger;

        public AccountController(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager
            ,RoleManager<IdentityRole> roleManager)
        {
            _UserManger=userManager;
            _SignInManger = signInManager;
            _RoleManger = roleManager;
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register (RegisterViewModel ViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = ViewModel.Email,
                    Email = ViewModel.Email
                    
                };
                var rusult = await _UserManger.CreateAsync(user, ViewModel.Password);
                
                if (rusult.Succeeded)
                {
                    
                   var result= await _UserManger.AddToRoleAsync(user, "User");
                    if (!result.Succeeded)
                    {
                        return View("Error");
                    }
                    await _SignInManger.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "Home");
                }
                else
                {
                    foreach(var error in rusult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(ViewModel);
        }
        public async Task<IActionResult> LogOut()
        {
            await _SignInManger.SignOutAsync();
            return RedirectToAction("index", "Home");
        }
        [HttpGet]
        public IActionResult LogIn (string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogIn (LogInViewModel ViewModel)
        {
            if (ModelState.IsValid)
            {
              var result=  await _SignInManger.PasswordSignInAsync(ViewModel.Email, ViewModel.Password, ViewModel.RememberMe, false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(ViewModel.ReturnUrl))
                    {
                        return LocalRedirect(ViewModel.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("index", "Home");

                    }
                   
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Log In Attemp");
                }

            }
            return View(ViewModel);
        }
    }
}
