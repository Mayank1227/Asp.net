
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcfirstApplication1.Models;

namespace MvcfirstApplication1.Controllers
{
    public class StudentExampleController : Controller
    {
        // GET: StudentExample
        [HttpGet]
        public ActionResult Index()
        {
            var studentlist = new List<Student>
            {
                    new Student(){StudentId=101,StudentName="vishal",Age=23},
                    new Student(){StudentId=102,StudentName="jayshree",Age=28},
                    new Student(){StudentId=103,StudentName="Nirav patel",Age=28}
            };
            return View(studentlist);
        }
    }
}