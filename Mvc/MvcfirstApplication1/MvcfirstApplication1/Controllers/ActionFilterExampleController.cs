using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcfirstApplication1.Controllers
{
    public class ActionFilterExampleController : Controller
    {
        // GET: ActionFilterExample
        [Log]
        public ActionResult Index()
        {
            return View();
        }
    }
}