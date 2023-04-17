using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBookingCar.Models.EF;
using WebBookingCar.Models;

namespace WebBookingCar.Areas.Admin.Controllers
{
    //[Authorize(Roles = "Admin")]

    public class CarImageController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/CarImage
        public ActionResult Index(int id)
        {
            ViewBag.CarId = id;
            var items = db.CarImages.Where(x => x.CarId == id).ToList();
            return View(items);
        }
        [HttpPost]
        public ActionResult AddImage(int CarId, string url)
        {
            db.CarImages.Add(new CarImage
            {
                CarId = CarId,
                Image = url,
                IsDefault = false
            });
            db.SaveChanges();
            return Json(new { Success = true });
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.CarImages.Find(id);
            db.CarImages.Remove(item);
            db.SaveChanges();
            return Json(new { success = true });
        }
    }
}