using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;
using System.Diagnostics;
using System.Globalization;
using System.Security.Claims;
using System.Xml.Linq;
using WebProgrammingProject.Models;
using WebProgrammingProject.Models.db;

namespace WebProgrammingProject.Controllers
{
    public class HomeController : Controller
    {
        //private readonly UserManager<ApplicationUser> _userManager;
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
        [Authorize(Roles = "C")]
        public IActionResult FindAppointment(homeViewModel model)
        {
            //gelen modelde once sehirleri ayirayim
            List<Shop> shops = (from sh in _context.Shop_t
                                where sh.City == model.city
                                select sh).ToList();
            List<Barber> barbers = new List<Barber>();
            List<Rendezvous> randevular = new List<Rendezvous>();
            List<Proficiencies> prf= (from p in _context.Proficiencies_t
                               
                                select p).ToList();

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

            //berberin o saatte randevusu var mi diye kontrol edeyim
            //randevu ile berberleri join edeyim
            //olan randevularin saatlerini o berberin divine ekliyim
            //berber ve randevulardan olusan bir dict olsun?
            //herbir berber icin bi cok deger olabilmeli
            foreach(Barber b in barbers)
            {
                randevular.AddRange((from r in _context.Rendezvous_t
                                     where r.BarberId == b.Id
                                     select r).ToList());
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
            var userRole = User.Identity.IsAuthenticated ? User.FindFirst(ClaimTypes.Role)?.Value : "Guest";
            ViewBag.UserRole = userRole;

            var newModel = new findAppointmentVM();
            newModel.barbers = barbers;
            newModel.tarih = model.tarih;
            newModel.hvm = model;
            newModel.randevular = randevular;
            newModel.prf = prf;
            return View(newModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>GetRandevu(int id,string TimeSlot, DateTime tarih,findAppointmentVM model,int selectedProf, int customerId) { 
            var barber = (from b in _context.Barber_t
                          where b.Id == id
                          select b).FirstOrDefault();

            var operation = (from o in _context.Proficiencies_t where selectedProf == o.Id select o).ToList();
            //zaten o saatin musait oldugunu  net olarak biliyorum
            //o saatte onaylanmasi icin randevuyu olusturmam lazim sadece
            //randevu sinifini olustururkenki eksiklerim nelermis bakalimmm
        
            var rendezvous = new Rendezvous();

            //string tarih_string = tarih.ToString();
            TimeOnly timeOnly = TimeOnly.ParseExact(TimeSlot, "hh:mm:ss tt", null);
            DateTime newDateTime = new DateTime(
                    tarih.Year, tarih.Month, tarih.Day,
                    timeOnly.Hour, timeOnly.Minute, timeOnly.Second);

            rendezvous.BarberId = id;
            rendezvous.When = newDateTime;
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var user = (from c in _context.Customer_t where c.Email== email select c).FirstOrDefault();
            rendezvous.CustomerId = user.Id;
            rendezvous.operation = (from p in _context.Proficiencies_t where p.Id == selectedProf select p).FirstOrDefault().name;
            //rendezvous.CustomerId ;
            //rendezvous.BarberId = model.
            //DateTime dt = DateTime.ParseExact(dateString, "yyyyMMdd-HHmmss", CultureInfo.InvariantCulture);
            //rendezvous.When = new DateTime(tarih.Date, new TimeOnly(TimeSlot));
            if (ModelState.IsValid)
            {
                rendezvous.When = DateTime.SpecifyKind(rendezvous.When, DateTimeKind.Utc);
                _context.Add(rendezvous);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {

            }
            return RedirectToAction("Index");
        }
        
        public IActionResult Randevular()
        {
            var model = new RandevuVM();
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            List<Rendezvous> randevularim = new List<Rendezvous>();
            Barber berber;
            Customer cstmr;
            int userid;
            if (userRole == "B")
            {
                berber = (from b in _context.Barber_t where b.Email == userEmail select b).FirstOrDefault();
                model.barber = berber;
                randevularim = (from r in _context.Rendezvous_t where r.BarberId == berber.Id select r).ToList();
            }
            else if(userRole == "C")
            {
                cstmr = (from c in _context.Customer_t where c.Email == userEmail select c).FirstOrDefault();
                model.user = cstmr;
                randevularim = (from r in _context.Rendezvous_t where r.CustomerId == cstmr.Id select r).ToList();
            }
            model.userRole = userRole;
            model.myRendezvous = randevularim;
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Randevular(int randevuId, string aksiyon)
        {
            var randevu = (from r in _context.Rendezvous_t where r.Id == randevuId select r).FirstOrDefault();
            if (randevu == null)
            {
                return NotFound();
            }
            if (aksiyon == "True")
                randevu.isApproved = false;
            else
                randevu.isApproved = true;


                _context.Update(randevu);
                await _context.SaveChangesAsync();

            return RedirectToAction("Randevular", "Home");
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