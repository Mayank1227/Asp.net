using InterviewManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterviewManagement.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            InterviewMethod db = new InterviewMethod();
            List<InterviewMaster> obj = db.GetAllCandidateDeshBoard();
            List<InterviewMaster> ABC = db.GetAllCandidate();
            List<InterviewMaster> obj1 = db.ScheduleInterviewDateMethod();
            List<InterviewMaster> SIM = db.ScheduleInterviewMethod();
           

            foreach (var item in ABC)
            {
                Session["PendingCandidateCount"] = item.TotalPendingInterviewCount;
            }

                foreach (var item in obj1)
            {
                Session["CandidateDate"] = item.InterviewDateCandite;
            }

            foreach (var item in SIM)
            {
                Session["TotalInterviewTypeCount"] = item.InProgressInterviewCount;
            }
               



            return View(obj);
            

        }

        public ActionResult List()
        {

            Method db = new Method();
            List<Master> obj = db.GetCompanyShowData();
            return View(obj);
        }

       
      

      
    }
}