using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcfirstApplication1.Controllers
{
    public class Tempdata2Controller : Controller
    {
        // GET: Tempdata2
        public ActionResult Index()
        {
            TempData["n1"] = 100;
            TempData["n2"] = 200;

            //return View();
            return RedirectToRoute("Second");
        }
    }
}