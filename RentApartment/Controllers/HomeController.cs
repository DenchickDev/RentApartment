using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using RentApartment.Models;

namespace RentApartment.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ApplicationContext db = new ApplicationContext();
            var app = db.Apartments.Include(x => x.TypeHome).Include(x => x.Address);
            return View(app);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AddApartment()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddApartment(Apartment model)
        {
            if (ModelState.IsValid)
            {
                ApplicationContext db = new ApplicationContext();
                var current_user = db.Users.Where(x => x.Email == HttpContext.User.Identity.Name).SingleOrDefault();
                Apartment apartment = new Apartment {
                    Florr = model.Florr,
                    Num_Floors = model.Num_Floors,
                    Num_Rooms = model.Num_Rooms,
                    Total_Area = model.Total_Area,
                    LivingArea = model.LivingArea,
                    KitchenArea = model.KitchenArea,
                    Price = model.Price,
                    rf_UsersId = current_user.Id,
                    rf_TypeHomeId = model.rf_TypeHomeId,
                    rf_AdressId = model.rf_AdressId
                };
                db.Apartments.Add(apartment);
                db.SaveChanges();
                //IdentityResult result = await UserManager.CreateAsync(user, model.Password);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

    }
}