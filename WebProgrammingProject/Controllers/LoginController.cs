using Microsoft.AspNetCore.Mvc;
//using WebProgrammingProject.Migrations;
using WebProgrammingProject.Models.db;
using System.Security.Claims;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Threading;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace WebProgrammingProject.Controllers
{
    public class LoginController : Controller
    {
        public readonly Db _context;

        public LoginController(Db context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {   
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string email, string password)
        {

            //var person = _context.Person_t.FirstOrDefault(u => u.Email == email && u.Password == password);
            var person = _context.Person_t.Where(p => p.Email == email && p.Password == password).FirstOrDefault();
            if (person != null) { 
                var shopkeeper = _context.Shopkeeper_t.FirstOrDefault(u => u.PersonalInfo.Email == email && u.PersonalInfo.Password == password);
                if (shopkeeper == null)
                {
                    var barber = _context.Barber_t.FirstOrDefault(u => u.PersonalInfo.Email == email && u.PersonalInfo.Password == password);
                    if (barber == null)
                    {
                        var customer = _context.Customer_t.FirstOrDefault(u => u.PersonalInfo.Email == email && u.PersonalInfo.Password == password);
                        if (customer == null)
                        {
                            ViewBag.ErrorMessage = "E-posta veya şifre hatalı.";
                            return View();
                        }
                        else
                        {
                            var claims = new List<Claim>
                            {
                            new Claim(ClaimTypes.Name, person.FirstName),
                            new Claim(ClaimTypes.Email, person.Email),
                            new Claim(ClaimTypes.Role, customer.Role) // Rolü sakla
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
                            new Claim(ClaimTypes.Name, person.FirstName),
                            new Claim(ClaimTypes.Email, person.Email),
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
                        new Claim(ClaimTypes.Name, person.FirstName),
                        new Claim(ClaimTypes.Email, person.Email),
                        new Claim(ClaimTypes.Role, shopkeeper.Role) // Rolü sakla
                        };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Index", "Shopkeeper");
                }
            }
            
            //hata mesaji eklerim
            return RedirectToAction("Index", "Login");
            
        }
    }
}
