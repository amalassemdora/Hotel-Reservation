using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        Divers_HotelEntities db = new Divers_HotelEntities();

        public ActionResult Index()
        {
            ViewBag.Meal = db.Meals.AsNoTracking().ToList();
            return View(ViewBag.Meal);
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Admin m)
        {
            if (ModelState.IsValid)
            {
                db.Admins.Add(m);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(m);
            }
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin m)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Admins.Add(m);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //else
            //{
                return View(m);
           // }
        }
    }
}