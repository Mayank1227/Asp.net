using MvcCrudApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCrudApplication.Controllers
{
    public class LoginFirstController : Controller
    {
        Mayank2dbEntities entity = new Mayank2dbEntities();
        // GET: LoginFirst
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            List<SelectListItem> usertype = new List<SelectListItem>();
            foreach (var item in UserReg.getUserType())
            {
                usertype.Add(new SelectListItem() { Text = item, Value = item });
            }

            ViewBag.UserType = usertype;
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserReg model, FormCollection fc)
        {
            model.UserType = fc["UserType"].ToString();
            try
            {
                if (model.UserEmailid != "")
                {
                    var data = entity.UserRegs.SingleOrDefault(m => m.UserType == model.UserType && m.UserEmailid == model.UserEmailid && m.Password == model.Password);

                    if (data == null)
                    {
                        ViewBag.error = "Emailid or password is wrong";
                    }
                    else
                    {
                        if (model.UserType == "Admin")
                        {
                            return RedirectToAction("Index", "Admin1");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Employee1");
                        }
                    }


                }
                else
                {
                    ViewBag.error = "Emailid or password is wrong";
                }



            }
            catch (Exception ex)
            {
                ViewBag.message = ex.Message;
            }
            List<SelectListItem> usertype = new List<SelectListItem>();
            foreach (var item in UserReg.getUserType())
            {

                usertype.Add(new SelectListItem() { Text = item, Value = item });
            }
            ViewBag.UserType = usertype;


            return View();
        }

       
    }
}



