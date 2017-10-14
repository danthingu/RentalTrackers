using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentalTrackers.Controllers
{
    [AllowAnonymous]
    public class NewRentalsController : Controller
    {
        // GET: NewRental
        public ActionResult New()
        {
            return View();
        }
    }
}