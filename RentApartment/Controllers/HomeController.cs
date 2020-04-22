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
            var model = new ApartmentAdd();
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> AddApartment(ApartmentAdd model)
        {
            if (ModelState.IsValid)
            {
                ApplicationContext db = new ApplicationContext();
                var current_user = db.Users.Where(x => x.Email == HttpContext.User.Identity.Name).SingleOrDefault();
                var current_address = db.Addresses.Where(x => x.Country == model.Country && x.Area == model.Area &&
                                                 x.City == model.City && x.District == model.District &&
                                                 x.Street == model.Street && x.House == model.House &&
                                                 x.Apartment == model.Apartment).SingleOrDefault();
                int addressID = 0;
                if(current_address == null)
                {
                    Address address = new Address
                    {
                        Country = model.Country,
                        Area = model.Area,
                        City = model.City,
                        District = model.District,
                        Street = model.Street,
                        House = model.House,
                        Apartment = model.Apartment
                    };
                    db.Addresses.Add(address);
                    db.SaveChanges();
                    addressID = address.Id;
                }
                else
                {
                    addressID = current_address.Id;
                }
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
                    rf_AdressId = addressID
                };
                db.Apartments.Add(apartment);
                db.SaveChanges();
                //IdentityResult result = await UserManager.CreateAsync(user, model.Password);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        public ActionResult OpenApartment(int idApartment)
        {
            ApplicationContext db = new ApplicationContext();
            var app = db.Apartments.Include(x => x.TypeHome).Include(x => x.Address);
            return View(app.Where(x => x.Id == idApartment).SingleOrDefault());
        }
    }
}