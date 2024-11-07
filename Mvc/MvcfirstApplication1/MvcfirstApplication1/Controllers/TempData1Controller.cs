using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcfirstApplication1.Controllers
{
    public class TempData1Controller : Controller
    {
        // GET: TempData1
        public ActionResult Index()
        {
            TempData["rollno"] = 109;
            TempData["name"] = "mayank patel";

            //return View();
            return RedirectToAction("ShowData");
           
        }
        public ActionResult ShowData()
        {
            return View();
        }
    }
}