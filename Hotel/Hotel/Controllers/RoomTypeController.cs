using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel.Controllers
{
    public class RoomTypeController : Controller
    {
        // GET: RoomType
        Divers_HotelEntities db = new Divers_HotelEntities();

        public ActionResult Index()
        {
            ViewBag.RoomType = db.Room_Type.AsNoTracking().ToList();
            return View(ViewBag.RoomType);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Room_Type m)
        {
            if (ModelState.IsValid)
            {
                db.Room_Type.Add(m);
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
            else
            {
                var data = db.Room_Type.Find(id);
                return View(data);
            }
        }
        [HttpPost]
        public ActionResult Edit(Room_Type m)
        {
            if (ModelState.IsValid)
            {
                db.Entry(m).State = EntityState.Modified;
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
				var data = db.Room_Type.Find(id);
				return View(data);
			}
		}
		[HttpPost]
		[ActionName("Delete")]
		public ActionResult ConfirmDelete(int id)
		{
            var count = 0;
            count = db.Rooms.Where(c => c.room_type == id ).Count();
            if (count > 0)
            {
                ViewBag.msg = "There are related Rooms, So you cannot delete this Room";
                return View();
            }
            else
            {
                var data = db.Room_Type.Find(id);
                db.Room_Type.Remove(data);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
		}
	}
}