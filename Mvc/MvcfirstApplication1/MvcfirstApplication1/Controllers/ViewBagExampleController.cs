using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcfirstApplication1.Controllers
{
    public class ViewBagExampleController : Controller
    {
        // GET: ViewBagExample
        public ActionResult Index()
        {
            ViewBag.rollno = 12;
            ViewBag.name = "Mayank";
            ViewBag.addreass = "ahmedabad";
            return View();
        }
        public ActionResult AddCalc()
        {
            ViewBag.a = 10;
            ViewBag.b = 20;

            return View();
        }
    }
}