using InterviewManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace InterviewManagement.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee       
        public ActionResult EmployeADD(int? id)
        {
            // If candidateId is provided, fetch existing data and load the update view
            if (id.HasValue)
            {
                EmployeeMethod IM = new EmployeeMethod();
                //InterviewMaster existingCandidate = IM.GetCandidateById(candidateId.Value);

                var existingEmployee = IM.GetEmployeeData().FirstOrDefault(model => model.EmployeeId == id);
                if (existingEmployee != null)
                {
                    // Populate the view model with existing data for update
                    return View(existingEmployee);
                }
                else
                {
                    // Handle the case where the candidate with the provided ID doesn't exist
                    return HttpNotFound();
                }
            }

            // If candidateId is not provided, load the insert view
            return View();
        }
        [HttpPost]
        public ActionResult EmployeADD(EmployeeMaster Emp)
        {
            ResponseBase response = new ResponseBase();
            try
            {
                EmployeeMethod EM = new EmployeeMethod();

                if (Emp.EmployeeId > 0)
                {
                    // Update existing candidate
                    bool check = EM.AddOrUpdateEmployee(Emp, out string errorMessage);
                    if (check)
                    {
                        TempData["Employeeerror"] = "Data updated successfully.";
                        //return RedirectToAction("EmployeList");
                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.ErrorDescription = errorMessage;
                    }
                }
                else
                {
                    // Insert new candidate
                    bool check = EM.AddOrUpdateEmployee(Emp, out string errorMessage);
                    if (check)
                    {
                        TempData["Employeeerror"] = "Data added successfully.";
                        //return RedirectToAction("EmployeList");
                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.ErrorDescription = errorMessage;
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorDescription = ex.Message;
            }
            // Return the response object as JSON
            return Json(new { errorDescription = response.ErrorDescription });
        }


        //------------------------------------------------- EmployeList ---------------------------------------
        public ActionResult EmployeList()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EmployeList(EmployeeMaster obj)
        {
            EmployeeMethod db = new EmployeeMethod();
            // Get employee data
            List<EmployeeMaster> employees = db.GetEmployeeData(obj);
            return View(employees);
        }


        //------------------------------------ Employee Delete -----------------------------------------------
        public ActionResult EmployeeDelete(int id)
        {
            try
            {
                EmployeeMethod context = new EmployeeMethod();
                bool check = context.DeleteEmployee(id);

                if (check)
                {
                    TempData["deleteMessage"] = "Data has been deleted successfully";
                    return RedirectToAction("EmployeList");
                }
                else
                {
                    TempData["deleteMessage"] = "Failed to delete data";
                    return RedirectToAction("EmployeList");
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (log it, display a user-friendly message, etc.)
                TempData["deleteMessage"] = "An error occurred while deleting data. Please try again later.";
                return RedirectToAction("EmployeList");
            }
        }




    }
}


