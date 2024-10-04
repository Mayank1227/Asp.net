using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InterviewManagement.Models;

namespace InterviewManagement.Controllers
{
	public class InterviewController : Controller
	{
		// Show Data
		public ActionResult CandidateList()
		{
			InterviewMethod db = new InterviewMethod();
			List<InterviewMaster> obj = db.GetAllCandidate();
			return View(obj);
		}

		// GET: Interview
		public ActionResult AddCandidate(int? id)
		{
			// If candidateId is provided, fetch existing data and load the update view
			if (id.HasValue)
			{
				InterviewMethod IM = new InterviewMethod();
				//InterviewMaster existingCandidate = IM.GetCandidateById(candidateId.Value);

				var existingCandidate = IM.GetAllCandidate().FirstOrDefault(model => model.CandidateId == id);
				if (existingCandidate != null)
				{
					// Populate the view model with existing data for update
					return View(existingCandidate);
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
		public ActionResult AddCandidate(InterviewMaster Inter)
		{
			ResponseBase response = new ResponseBase();
			try
			{
				//if (ModelState.IsValid)
				//{
				InterviewMethod IM = new InterviewMethod();

				if (Inter.CandidateId > 0)
				{
					// Update existing candidate
					bool check = IM.AddOrUpdateCandidate(Inter, out string errorMessage);
					if (check)
					{
						TempData["interviewerror"] = "Candidate Data updated successfully.";
						//return RedirectToAction("CandidateList");
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
					bool check = IM.AddOrUpdateCandidate(Inter, out string errorMessage);
					if (check)
					{
						TempData["interviewerror"] = "New Candidate added successfully.";
						//return RedirectToAction("CandidateList");
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
			// Return the ErrorDescription property as a JSON response
			return Json(new { errorDescription = response.ErrorDescription });
		}


		// Delete Candidate
		public ActionResult CandidateDelete(int id)
		{

			try
			{
				InterviewMethod context = new InterviewMethod();

				bool check = context.DeleteCandidate(id);

				if (check)
				{
					TempData["interviewerror"] = "Data has been deleted successfully";
					return RedirectToAction("CandidateList");
				}
				else
				{
					TempData["interviewerror"] = "Failed to delete data";
					return RedirectToAction("CandidateList");
				}
			}
			catch (Exception ex)
			{
				// Handle the exception (log it, display a user-friendly message, etc.)
				TempData["deleteMessage"] = ex.Message;
				return RedirectToAction("CandidateList");
			}
		}


		// GET :  ScheduleInterview
		public ActionResult ScheduleInterview(int id)
		{
			
			EmployeeMethod EM = new EmployeeMethod();
			ViewBag.AllEmplloyee = EM.GetEmployeeData();

			InterviewMethod IM = new InterviewMethod();
			var existingCandidate = IM.GetAllCandidate().FirstOrDefault(model => model.CandidateId == id);

			// Populate the view model with existing data for update
			return View(existingCandidate);

		}

		// Post :  ScheduleInterview
		[HttpPost]
		public ActionResult ScheduleInterview(InterviewMaster Inter,ScheduleInterviewDB obj)
		{
			ResponseBase response = new ResponseBase();

			try
			{
				InterviewMethod interobj = new InterviewMethod();
				// Send interview message to the email address
				bool check = interobj.SendInterviewEmail(Inter, obj);
				if (check)
				{
					response.IsSuccess = true;
					response.ErrorDescription = "Email sent successfully";

				}


				bool Checkdata = interobj.AddScheduleInterview(obj);
				if (Checkdata)
				{
					response.IsSuccess = true;
					response.ErrorDescription = "Email sent successfully";

					TempData["ScheduleInterviewSuccess"] = "Email sent successfully";
					return RedirectToAction("ScheduleInterviewList");
				}
				else
				{
					response.IsSuccess = false;
					response.ErrorDescription = "data not insserted...";
					TempData["ScheduleInterviewSuccess"] = "data not insserted...";
				}
				return RedirectToAction("CandidateList");

			}
			catch (Exception ex)
			{
				TempData["ScheduleInterviewSuccess"] = ex.Message;
				return RedirectToAction("CandidateList");
			}				
		}

		// ScheduleInterviewList

		public ActionResult ScheduleInterviewList()
		{
			InterviewMethod db = new InterviewMethod();
			List<InterviewMaster> obj = db.ScheduleInterviewMethod();
			return View(obj);
		}


		// ScheduleInterviewDate
		public ActionResult ScheduleInterviewDate()
		{
			InterviewMethod db = new InterviewMethod();
			List<InterviewMaster> obj = db.ScheduleInterviewDateMethod();

			return View(obj);
		}
	}
}
