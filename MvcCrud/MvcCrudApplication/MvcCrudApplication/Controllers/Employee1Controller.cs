using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCrudApplication.Controllers
{
    public class Employee1Controller : Controller
    {
        // GET: Employee1
        public ActionResult Index()
        {
            return View();
        }
    }
}