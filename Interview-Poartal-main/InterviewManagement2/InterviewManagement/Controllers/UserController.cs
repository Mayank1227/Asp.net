using InterviewManagement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterviewManagement.Controllers
{
    public class UserController : Controller
    {
        // GET: CompanyDeatils
        public ActionResult Show()
        {
            
            return View();
        }


        //-------------------------------Login Controller---------------------------------------------//

       
        public ActionResult Login()
        {

            return View();
        }

       
        [HttpPost]
        public ActionResult Login(LoginModel CL)
        {
            LoginDB CM = new LoginDB();

            bool check = CM.isAuth(CL);

            try
            {
                if (check)
                {
                    Session["CompanyName"] = CL.CompanyName;
                    Session["CompanyId"] = CL.CompanyId;
                    Session["CompanyEmail"] = CL.CompanyEmail;
                    Session["CompanyEmailSmtpPassword"] = CL.CompanyEmailSmtpPassword;

                    return Json(new { success = true, message = "Login Successfully" });
                  
                    // Login success code
                }
                else
                {
                    return Json(new { success = false, message = "Username or password invalid." });
                    // Login failed code
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        //-------------------------------Registration Controller---------------------------------------------///


        public ActionResult Registration(int? id)
        {




            // If candidateId is provided, fetch existing data and load the update view
            if (id.HasValue)
            {
                Method context = new Method();
                var row = context.GetCompanyShowData().Find(model => model.CompanyId == id.Value);
                if (row != null)
                {
                    // Populate the view model with existing data for update
                    return View(row);
                }
                else
                {
                    // Handle the case where the candidate with the provided ID doesn't exist
                    return HttpNotFound();
                }
            }
            return View();
        }


        [HttpPost]
        public ActionResult Registration(Master Emp)
        {
            ResponseBase response = new ResponseBase();
            try
            {
                // Create an instance of the Method class
                Method ME = new Method();
                

                // Validate if the CompanyId is greater than 0
                if (Emp.CompanyId > 0)
                {
                    // File handling
                   
                    string path = Server.MapPath("~/App_Data/File");
                    string filename = Path.GetFileName(Emp.File.FileName);
                    string fullpath = Path.Combine(path, filename);
                    Emp.File.SaveAs(fullpath);

                    // Update existing company
                    bool check = ME.AddOrUpdateCompanay(Emp, fullpath, out string errorMessage);

                    if (check)
                    {
                        response.IsSuccess = true;
                        response.ErrorDescription = "Data updated successfully.";
                        TempData["Companyerror"] = response.ErrorDescription;
                        return RedirectToAction("List", "Home"); // Redirect to the List action in the Home controller
                    }
                }
                else
                {
                    // CompanyId is not greater than 0, indicating a new company

                    // File handling
                   

                    string path = Server.MapPath("~/App_Data/File");
                    string filename = Path.GetFileName(Emp.File.FileName);
                    string fullpath = Path.Combine(path, filename);
                    Emp.File.SaveAs(fullpath);

                    // Insert new company
                    bool check = ME.AddOrUpdateCompanay(Emp, fullpath, out string errorMessage);

                    if (check)
                    {
                        response.IsSuccess = true;
                        response.ErrorDescription = "Registration  successfully.";
                        TempData["Companyerror"] = response.ErrorDescription;
                        return RedirectToAction("Login"); // Redirect to the Login action
                    }
                    else
                    {
                        response.IsSuccess = false;
                        TempData["Companyerror"] = errorMessage;
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorDescription = ex.Message;
                TempData["Companyerror"] = response.ErrorDescription;
            }

            return View();
        }

        // Delete   
        public ActionResult Delete(int id, Master emp)
        {
            try
            {
                Method context = new Method();
                bool check = context.DeleteCompany(id);

                if (check)
                {
                    TempData["deleteMessage"] = "Data has been deleted successfully";
                    return RedirectToAction("List", "Home");
                }
                else
                {
                    TempData["deleteMessage"] = "Failed to delete data";
                    return RedirectToAction("List", "Home");
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (log it, display a user-friendly message, etc.)
                TempData["deleteMessage"] = "An error occurred while deleting data. Please try again later.";
                return RedirectToAction("List", "Home");
            }
        }


    }
}
                               

    



