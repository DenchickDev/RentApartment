using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using RentApartment.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Security.Principal;
using System.Data.Entity;

namespace RentApartment.Controllers
{
    public class ManageController : Controller
    {
        public ActionResult AboutUser()
        {
            ApplicationContext db = new ApplicationContext();
            var current_user = db.Users.Where(x => x.Email == HttpContext.User.Identity.Name).SingleOrDefault();
            var app = db.Apartments.Include(x => x.TypeHome).Include(x => x.Address).Where(x => x.rf_UsersId == current_user.Id);
            return View(app);
        }
    }
}
