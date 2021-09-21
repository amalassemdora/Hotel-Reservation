using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel.Models;

namespace Hotel.Controllers
{
    public class CustomerController : Controller
    {
        // object of database
        Divers_HotelEntities db = new Divers_HotelEntities();
        public ActionResult Index()
        {
            ViewBag.id = 0;
            ViewBag.customer = db.customers.AsNoTracking().ToList();
            return View(ViewBag.customer);
        }
        public ActionResult Search(string txt)
        {
            ViewBag.customer = db.customers.Where(c=>c.Name.Contains(txt)).ToList();
            return View(ViewBag.customer);
        }
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return HttpNotFound("This Id is not found");
            }
            else
            {
                var data = db.customers.Find(id);
                return View(data);
            }
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.RoomType = new SelectList(db.Room_Type, "id", "room_type1");
            ViewBag.MealType = new SelectList(db.Meals,"meal_id", "meal_name");
           // ViewBag.RoomNo = new SelectList(db.Rooms, "roomtype", "id");
            return View();
        }

        [HttpPost]
        public ActionResult Create(customer c)
        {
			if (ModelState.IsValid)
			{
				db.customers.Add(c);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			else
			{
				ViewBag.RoomType = new SelectList(db.Room_Type, "id", "room_type1");
				ViewBag.RoomNo = new SelectList(db.Rooms, "roomtype", "id");
				return View(c);
			}
		}
        public ActionResult Edit(int id)
        {
            var data = db.customers.Find(id);
            ViewBag.RoomType = new SelectList(db.Room_Type, "id", "room_type1");
            ViewBag.MealType = new SelectList(db.Meals, "meal_id", "meal_name");
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(customer c)
        {
            if (ModelState.IsValid)
            {
                db.Entry(c).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(c);
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
                var data = db.customers.Find(id);
                return View(data);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
                var data = db.customers.Find(id);
                db.customers.Remove(data);
                db.SaveChanges();
                return RedirectToAction("Index");
            
        }
        public JsonResult GetRoom(int _roomtype)
		{
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.Rooms.Where(m => m.room_type == _roomtype).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
		}

    }
}
