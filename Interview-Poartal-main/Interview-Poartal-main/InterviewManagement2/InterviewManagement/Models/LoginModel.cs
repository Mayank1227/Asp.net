using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace InterviewManagement.Models
{
	public class LoginModel
	{
		public long CompanyId { get; set; }
		public string CompanyName { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public string CompanyEmailSmtpPassword { get; internal set; }
		public string CompanyEmail { get; internal set; }
	}
}