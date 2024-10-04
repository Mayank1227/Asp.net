using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InterviewManagement.Models
{
    public class Master
    {
        
        public long CompanyId { get; set; }
        public int IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long CompanyDetailId { get; set; }
       
        public string CompanyName { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string CompanyShortName { get; set; }
        public string PanCardNo { get; set; }
        public string GSTNo { get; set; }
        [Required]
        public HttpPostedFileBase File { get; set; }

     
       // public string EmailSmtpPassword { get; set; }
    }
}


