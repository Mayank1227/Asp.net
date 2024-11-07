using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcfirstApplication1.Controllers
{
    public class ViewDataExampleController : Controller
    {
        // GET: ViewDataExample
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DisplayInformation()
        {
            ViewData["empid"] = 1001;
            ViewData["empName"] = "Patel Mayank";
            ViewData["designation"] = "Senior trainer";
            return View();
        }
        public ActionResult Multiply()
        {
            ViewData["first"] = 100;
            ViewData["Second"] = 200;
            return View();
        }

    }
}