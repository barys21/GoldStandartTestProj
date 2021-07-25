using GoldStandartTestProj.Data;
using GoldStandartTestProj.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GoldStandartTestProj.Controllers
{

    public class UserController : Controller
    {
        private readonly ApplicationContext context;
        public UserController(ApplicationContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            var role = context.Roles.ToList();
            ViewBag.Role = new SelectList(role, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (user != null)
            {
                context.Users.Add(user);
                context.SaveChanges();
                return Redirect("~/Home/Index");
            }
            else
            {
                return Content("Что-то пошло не так!");
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(User user)
        {
            User result = context.Users.FirstOrDefault(f => f.Email == user.Email && f.Password == user.Password);
            if (result != null)
            {
                _ = Authenticate(result);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }

            return View(user);
        }

        private async Task Authenticate(User userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, userName.Role?.Name)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Home", "Index");
        }
    }
}
