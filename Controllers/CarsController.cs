using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBookingCar.Models;
using WebBookingCar.Models.EF;

namespace WebBookingCar.Controllers
{
    public class CarsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cars
        public ActionResult Index()
        {
            var cars = db.Cars.Include(c => c.CarCategory);
            return View(cars.ToList());
        }
    }
}
