using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel.Controllers
{
    public class RoomController : Controller
    {
        // GET: Room
        Divers_HotelEntities db = new Divers_HotelEntities();

        public ActionResult Index()
        {
            ViewBag.Room = db.Rooms.AsNoTracking().ToList();
            return View(ViewBag.Room);
        }
        public ActionResult Create()
        {
            ViewBag.RoomType = new SelectList(db.Room_Type, "id", "room_type1");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Room m)
        {
            if (ModelState.IsValid)
            {
                db.Rooms.Add(m);
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
                var data = db.Rooms.Find(id);
                ViewBag.RoomType = new SelectList(db.Room_Type, "id", "room_type1");
                return View(data);
            }
        }
        [HttpPost]
        public ActionResult Edit(Room m)
        {
            if (ModelState.IsValid)
            {
                ViewBag.RoomType = new SelectList(db.Room_Type, "id", "room_type1");
                db.Entry(m).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.RoomType = new SelectList(db.Room_Type, "id", "room_type1");
                return View(m);
            }
        }
        //public ActionResult Delete(int? id)
        //{

        //    if (id == null)
        //    {
        //        return HttpNotFound("This Id is not found");
        //    }
        //    else
        //    {
        //        var data = db.Rooms.Find(id);
        //        return View(data);
        //    }
        //}
        //[HttpPost]
        //[ActionName("Delete")]
        //public ActionResult ConfirmDelete(int id)
        //{
        //        var data = db.Rooms.Find(id);
        //        db.Rooms.Remove(data);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
           
        //}
    }
}
