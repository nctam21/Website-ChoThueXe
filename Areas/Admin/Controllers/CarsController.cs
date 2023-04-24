using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Web.UI;
using System.Windows.Controls;
using WebBookingCar.Models;
using WebBookingCar.Models.EF;

namespace WebBookingCar.Areas.Admin.Controllers
{
    public class CarsController : Controller
    {
        // GET: Admin/Cars
       
            private ApplicationDbContext db = new ApplicationDbContext();
           
            public ActionResult Index(int? page)
            {
                IEnumerable<Car> items = db.Cars.OrderByDescending(x => x.Id);
                var pageSize = 10;
                if (page == null)
                {
                    page = 1;
                }
                var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
                items = items.ToPagedList(pageIndex, pageSize);
                ViewBag.PageSize = pageSize;
                ViewBag.Page = page;
                return View(items);
            }
            public ActionResult Add()
            {
                ViewBag.Carcategory = new SelectList(db.CarCategories.ToList(), "Id", "Title");
                return View();
            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Add(Car model, List<string> Images, List<int> rDefault)
            {
                if (ModelState.IsValid)
                {
                    if (Images != null && Images.Count > 0)
                    {
                        for (int i = 0; i < Images.Count; i++)
                        {
                            if (i + 1 == rDefault[0])
                            {
                                model.Image = Images[i];
                                model.CarImage.Add(new CarImage
                                {

                                    CarId = model.Id,
                                    Image = Images[i],
                                    IsDefault = true
                                });
                            }
                            else
                            {
                                model.CarImage.Add(new CarImage
                                {
                                    CarId = model.Id,
                                    Image = Images[i],
                                    IsDefault = false
                                });
                            }
                        }
                    }
                    model.CreateDate = DateTime.Now;
                    model.ModifiedDate = DateTime.Now;
                    if (string.IsNullOrEmpty(model.SeoTitle))
                    {
                        model.SeoTitle = model.Title;
                    }
                    model.Alias = WebBookingCar.Models.Common.Filter.FilterChar(model.Title);
                    db.Cars.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.Carcategory = new SelectList(db.CarCategories.ToList(), "Id", "Title");
                return View(model);
            }
            public ActionResult Edit(int id)
            {
                ViewBag.Carcategory = new SelectList(db.CarCategories.ToList(), "Id", "Title");
                var item = db.Cars.Find(id);
                return View(item);
            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(Car model)
            {
                if (ModelState.IsValid)
                {
                    model.ModifiedDate = DateTime.Now;
                    model.Alias = WebBookingCar.Models.Common.Filter.FilterChar(model.Title);
                    db.Cars.Attach(model);
                    db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            [HttpPost]
            public ActionResult Delete(int id)
            {
                var item = db.Cars.Find(id);
                if (item != null)
                {
                    db.Cars.Remove(item);
                    db.SaveChanges();
                    return Json(new { success = true });
                }
                return Json(new { success = false });
            }
        [HttpPost]
        public ActionResult DeleteAll(string ids)
        {
            if (!string.IsNullOrEmpty(ids))
            {
                var items = ids.Split(',');
                if (items != null && items.Any())
                {
                    foreach (var item in items)
                    {
                        var obj = db.Cars.Find(Convert.ToInt32(item));
                        db.Cars.Remove(obj);
                        db.SaveChanges();
                    }
                }
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
        public ActionResult IsActive(int id)
            {
                var item = db.Cars.Find(id);
                if (item != null)
                {
                    item.IsActive = !item.IsActive;
                    db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, isActive = item.IsActive });
                }
                return Json(new { success = false });
            }
        
        

    }

}

