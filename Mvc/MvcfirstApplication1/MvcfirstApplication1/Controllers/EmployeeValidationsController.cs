using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcfirstApplication1.Controllers
{
    public class EmployeeValidationsController : Controller
    {
        // GET: EmployeeValidations
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(EmployeeValidations model)
        {
            return View(model);
        }
    }
}