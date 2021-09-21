using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel.Controllers
{
    public class MealController : Controller
    {
        // GET: Meal
       Divers_HotelEntities db = new Divers_HotelEntities();

        public ActionResult Index()
        {
            ViewBag.Meal = db.Meals.AsNoTracking().ToList();
            return View(ViewBag.Meal);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Meal m)
        {
			if (ModelState.IsValid)
			{
				db.Meals.Add(m);
            db.SaveChanges();
            return RedirectToAction("Index");
            }
			else
			{
				return View(m);
			}
		}
        public ActionResult Edit(int? id)
        {
            if (id == null)
			{
                return HttpNotFound("This Id is not found");
			}
			else {
            var data = db.Meals.Find(id);
            return View(data);
            }
        }
        [HttpPost]
        public ActionResult Edit(Meal m)
        {
            if (ModelState.IsValid)
            {
                db.Entry(m).State=EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(m);
            }
        }
        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return HttpNotFound("This Id is not found");
            }
            else
            {
                var data = db.Meals.Find(id);
                return View(data);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var count = 0;
            count = db.customers.Where(c => c.meal_id == id).Count();
			if (count > 0)
			{
                ViewBag.msg = "There are related customers, So you cannot delete this meal";
                return View();
			}
			else
			{
                var data = db.Meals.Find(id);
                db.Meals.Remove(data);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}