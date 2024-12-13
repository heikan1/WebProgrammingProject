using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;
using System.Diagnostics;
using System.Globalization;
using WebProgrammingProject.Models;
using WebProgrammingProject.Models.db;

namespace WebProgrammingProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly Db _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(Db context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }


        public IActionResult Index()
        {
            List<string> cities = (from sh in _context.Shop_t
                                select sh.City).ToList();
            if(cities == null)
            {
                cities = new List<string>();
            }
            ViewBag.cities = cities;
            var model = new homeViewModel();
            //ViewBag.shIds = cities;
            //var model = new Shop();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FindAppointment(homeViewModel model)
        {
            //gelen modelde once sehirleri ayirayim
            List<Shop> shops = (from sh in _context.Shop_t
                                where sh.City == model.city
                                select sh).ToList();
            List<Barber> barbers = new List<Barber>();

            bool doHave = false;
            // o gun acik mi dukkan ona bakiyorum
           foreach (Shop sh in shops.ToList()) {
                foreach(DayOfWeek dw in sh.SelectedDays)
                {
                    var gunTr = model.tarih.ToString("dddd");
                    var gundk = dw.ToString();
                    if (gundk == gunTr)
                    {
                        doHave = true;
                    }
                }
                if (!doHave)
                {
                    shops.Remove(sh);
                }
                doHave = false;
           }
            //o gun acik olan dukkanlari buldum
            //o gun mesaisi olan berberleri de bulup listeleyeyim sadece
            //o magazadaki berberleri aldim
            foreach (Shop sh in shops)
            {
                barbers.AddRange(
                        (from b in _context.Barber_t
                         where b.ShopId == sh.Id
                         select b)
                    );              
            }
            foreach (Barber b in barbers.ToList())
            {
                foreach (DayOfWeek dw in b.SelectedDays)
                {
                    var gunTr = model.tarih.ToString("dddd");
                    var gundk = dw.ToString();
                    if (gundk == gunTr)
                    {
                        doHave = true;
                    }
                }
                if (!doHave)
                {
                    barbers.Remove(b);
                }
                doHave = false;
            }
            
            //o saatte acik mi ona bakicam
            //ana saat secmiyom ki burada ok
            /*foreach (var sh in shops)
            {
                if(sh.StartTime <)
            }*/
            //eger o saatte aciksa bir de o saatte musait berber var mi diye bakicam
            //eger ki varsa listelicem
            //ulan islemi de mi ilk ekranda sectirsem

            var newModel = new findAppointmentVM();
            newModel.barbers = barbers;
            return View(newModel);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}