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
            ViewBag.customer = db.customers.AsNoTracking().ToList();
            return View(ViewBag.customer);
        }
        public ActionResult Details(int id)
        {
            var data = db.customers.Find(id);
            return View(data);
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
            // ViewBag.RoomNo = new SelectList(db.Rooms, "roomtype", "id");
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

        public JsonResult GetRoom(int roomtype)
		{
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.Rooms.Where(m => m.room_type == roomtype).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
		}

    }
}
