using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebProgrammingProject.Models.db;

namespace WebProgrammingProject.Controllers
{

    [Authorize(Roles = "A")]
    public class ShopkeeperController : Controller
    {
        private readonly Db _context;

        public ShopkeeperController(Db context)
        {
            _context = context;
        }
        [Authorize(Roles = "A")]
        public IActionResult Index()
        {
            return View();
        }
    }
}