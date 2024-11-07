using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Net;
using System.IO;
using MvcCrudApplication.Models;


namespace MvcCrudApplication.Models
{

    public class UserRegistrationController : Controller
    {
        Mayank2dbEntities entity = new Mayank2dbEntities();

        // GET: UserRegistration
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Save()
        {
            List<SelectListItem> countrylist = new List<SelectListItem>();
            foreach (var item in UserReg.getCountry())
            {
                countrylist.Add(new SelectListItem() { Value = item, Text = item });
            }

            ViewBag.Country = countrylist;
            return View();
        }
        [HttpPost]
        public ActionResult Save(FormCollection fc, HttpPostedFileBase image, UserReg model)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    model.UserType = fc["UserType"].ToString();
                    Convert.ToInt32(fc["Userid"].ToString());
                    model.UserName = fc["UserName"].ToString();

                    model.UserEmailid = fc["UserEmailid"].ToString();

                    model.Password = fc["Password"].ToString();
                    model.Country = fc["Country"].ToString();

                    //   Convert.ToInt32(fc["Country"].ToString());

                    model.State = fc["State"].ToString();

                    string dir = Server.MapPath("~/Content/ImageMy/");
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }
                    string fileName = image.FileName;  //img1.jpg
                    string filepath = dir + fileName;  //~/Content/ImageMy/img1.jpg;

                    image.SaveAs(filepath);

                    model.UserProfileImage = fileName;

                    entity.UserRegs.Add(model);
                    entity.SaveChanges();

                    ViewBag.message = "Registration Successfully";

                    List<SelectListItem> countrylist = new List<SelectListItem>();
                    foreach (var item in UserReg.getCountry())
                    {
                        countrylist.Add(new SelectListItem() { Value = item, Text = item });
                    }

                    ViewBag.Country = countrylist;



                }
                catch (Exception ex)
                {
                    ViewBag.error = ex.Message;
                }
            }

            return View(model);
        }


        public ActionResult Display()
        {
            return View(entity.UserRegs.ToList());
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            var item = entity.UserRegs.Find(id);
            if (id == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int? id)
        {
            UserReg m = entity.UserRegs.Find(id);

            entity.UserRegs.Remove(m);
            entity.SaveChanges();

            return RedirectToAction("Display");
            // return View(item);
        }

        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                var data = entity.UserRegs.SingleOrDefault(m => m.Userid == id);

                if (data != null)
                {
                    return View(data);
                }
                else
                {
                    return HttpNotFound();
                }
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

        }
        [HttpPost]
        public ActionResult Edit(int? id, UserReg model)
        {
            try
            {
                entity.Entry(model).State = System.Data.Entity.EntityState.Modified;
                entity.SaveChanges();

            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            return RedirectToAction("Display");
            //return View();
        }


    }
}