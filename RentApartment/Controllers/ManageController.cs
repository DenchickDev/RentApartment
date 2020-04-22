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
            //ViewBag.Message = "Your contact page.";

            ApplicationContext db = new ApplicationContext();
            var app = db.Apartments.Include(x => x.TypeHome).Include(x => x.Address);
            return View(app);
        }
    }
}
