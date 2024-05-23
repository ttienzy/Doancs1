using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MVCdemo.Dtos;
using MVCdemo.Models;

namespace MVCdemo.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn([Bind("UserName", "Password")] LogInAccount model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await _signInManager.PasswordSignInAsync(model.UserName!, model.Password!, true, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Invalid SignIn atempt");
                return View(model);
            }
            return RedirectToAction("Homepage", "Home");
        }


        [HttpPost]
        public async Task<IActionResult> LogI0([Bind("UserName", "Password", "Email")] CreateAccountDto model)
        {

            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                };
                var result = await _userManager.CreateAsync(appUser, model.Password!);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(appUser, false);
                    return View(nameof(LogIn));
                }
                foreach (var user in result.Errors)
                {
                    ModelState.AddModelError("", user.Description);
                }
            }
            return View(model);
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Homepage", "Home");
        }
    }
}