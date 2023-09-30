using Hotel_Project.Data;
using Hotel_Project.Migrations;
using Hotel_Project.Models.Entities.Account;
using Hotel_Project.ViewModels.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using Microsoft.Win32;
using System.Security.Claims;
using User = Hotel_Project.Models.Entities.Account.User;
using System;

namespace Hotel_Project.Controllers
{
    public class AccountController : Controller
    {
        MyContext _context;

        public AccountController(MyContext context)
        {
            _context = context;

        }

        #region Register

        [Route("register")]
        public IActionResult Register()
        {
            return View();
        }

        [Route("register"), HttpPost, ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                if (_context.users.Any(u => u.Email == register.Email))
                {
                    ModelState.AddModelError("Email", "ایمیل شما تکراری میباشد");
                    return View(register);
                }

                var user = new User
                {
                    Email = register.Email,
                    Password = register.Password
                };

                _context.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            ModelState.AddModelError("ModelOnly", "لطفا فیلدهارا کامل پر کنید");
            return View(register);
        }

        #endregion

        #region Login

        [Route("/Login")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("/Login"), HttpPost, ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                var user = _context.users.SingleOrDefault(u => u.Email == login.Email);
                if (user != null)
                {
                    if (user.Password == login.Password)
                    {
                        var claims = new List<Claim>()
                        {
                            new Claim(ClaimTypes.Role, "Basic" ),
                            new Claim(ClaimTypes.Name,user.Email),
                            new Claim(ClaimTypes.NameIdentifier , user.Id.ToString()),
                            new Claim(ClaimTypes.Email, login.Email)

                        };

                        var Identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                        var Principal = new ClaimsPrincipal(Identity);

                        var Properties = new AuthenticationProperties()
                        {
                            IsPersistent = login.IsRemeberMe
                        };

                        HttpContext.SignInAsync(Principal, Properties);
                        return RedirectToAction("UserDashboard", "Account");


                    }
                    ModelState.AddModelError("Email", "اطلاعات وارد شده صحیح نمیباشد");
                    return View();
                }
                ModelState.AddModelError("Email", "اطلاعات وارد شده صحیح نمیباشد");
                return View();
            }
            ModelState.AddModelError("Email", "لطفا فیلدهارا کامل پر کنید");
            return View();
        }

        #endregion

        #region Logou
        [Route("/Logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("login");
        }

        #endregion


        #region UserDashborad
        [Authorize]
        public IActionResult UserDashboard()
        {

            {
                return View();
            }

        }
        [Route("/EditUser")]

        public IActionResult EditUser()
        {
            UserDto usr = new();
            var user = _context.users.Where(e => e.Email == User.Identity.Name).FirstOrDefault();
            usr.Email = user.Email;
            usr.Name = user.Name;
            usr.LastName = user.LastName;
            usr.id = user.Id;

            return View(usr);
        }
        [Route("/EditUser"), HttpPost, ValidateAntiForgeryToken]

        public IActionResult EditUser(UserDto profile)
        {
            if (ModelState.IsValid)

            {

                var user = _context.users.Where(x => x.Id == profile.id).FirstOrDefault();
                if (user is not null)
                {

                    user.Name = profile.Name;
                    user.LastName = profile.LastName;
                }

                _context.SaveChanges();

            }
            return View();
        }


        #endregion
    }
}
