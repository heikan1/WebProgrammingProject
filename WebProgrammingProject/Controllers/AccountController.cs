﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebProgrammingProject.Models.db;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace WebProgrammingProject.Controllers
{
    public class AccountController : Controller
    {
        public readonly Db _context;

        public AccountController(Db context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        //logini buraya tasimak daha iyi olacak
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string password)
        {
            //var person = _context.Person_t.FirstOrDefault(u => u.Email == email && u.Password == password);
            var customer = _context.Customer_t.Where(p => p.Email == email && p.Password == password).FirstOrDefault();
            if (customer == null)
            {
                var shopkeeper = _context.Shopkeeper_t.FirstOrDefault(u => u.Email == email && u.Password == password);
                if (shopkeeper == null)
                {
                    var barber = _context.Barber_t.FirstOrDefault(u => u.Email == email && u.Password == password);
                    if (barber == null)
                    {
                        ViewBag.WarningMessage = "Invalid email or password. Please try again."; 
                        return View();
                    }
                    else
                    {
                        var claims = new List<Claim>
                            {
                            new Claim(ClaimTypes.Name, barber.FirstName),
                            new Claim(ClaimTypes.Email, barber.Email),
                            new Claim(ClaimTypes.Role, barber.Role) // Rolü sakla
                            };
                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    var claims = new List<Claim>
                        {
                        new Claim(ClaimTypes.Name, shopkeeper.FirstName),
                        new Claim(ClaimTypes.Email, shopkeeper.Email),
                        new Claim(ClaimTypes.Role, shopkeeper.Role) // Rolü sakla
                        };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Index", "Shopkeeper");
                }
            }
            else
            {
                var claims = new List<Claim>
                        {
                        new Claim(ClaimTypes.Name, customer.FirstName),
                        new Claim(ClaimTypes.Email, customer.Email),
                        new Claim(ClaimTypes.Role, customer.Role), // Rolü sakla
                        //new Claim(ClaimTypes.Authentication, customer.Id)
                        };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                //hata mesaji eklerim
                return RedirectToAction("Index", "Home");
            }

        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public /*async Task<*/IActionResult Logout()
        {
            //await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //await HttpContext.log
            foreach (var cookie in Request.Cookies)
            {
                Response.Cookies.Delete(cookie.Key); // Deletes each cookie.
            }
            return RedirectToAction("Index","Home");
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Register(Customer c)
        {
            if (ModelState.IsValid)
            {
                //dbye kaydet ve cookie olustur kismi
                _context.Add(c);
                await _context.SaveChangesAsync();

                var claims = new List<Claim>
                        {
                        new Claim(ClaimTypes.Name, c.FirstName),
                        new Claim(ClaimTypes.Email, c.Email),
                        new Claim(ClaimTypes.Role, c.Role) // Rolü sakla
                        };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                //hata mesaji eklerim
                return RedirectToAction("Index", "Home");

                //return RedirectToAction("Login", new { email = c.Email, password = c.Password });
            }
            //hata kismi
            ViewBag.ErrorMessage = "Kayit Basarisiz Lutfen Tekrar Deneyiniz!";
            return View();
        }
    }
}
