using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }
        //      public string Display(string name)
        //{
        //          return "Welcome "+ name;
        //}
        /* *****************Ajax*****************
        public JsonResult Display(string name)
        {
            var data = "Welcome " + name;
            return Json(data,JsonRequestBehavior.AllowGet);
        }*/
        public ActionResult Search()
		{
            return View();
		}
    }
}