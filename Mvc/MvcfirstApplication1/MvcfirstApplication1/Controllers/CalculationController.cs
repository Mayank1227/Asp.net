using MvcfirstApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcfirstApplication1.Controllers
{
    public class CalculationController : Controller
    {
        // GET: Calculation
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(AdditionModel model, string command)
        {
            if(command=="add")
            {
                model.result = model.a + model.b;
            }
            else if (command=="sub")
            {
                model.result = model.a - model.b;
            }
            else
            {
                model.result = model.a * model.b;
            }
            return View(model);
        }
    }
}