using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewManagement.Models
{
	public class ResponseBase
	{
		public bool IsSuccess { get; set; }
		public string ErrorDescription { get; set; }
	}
}