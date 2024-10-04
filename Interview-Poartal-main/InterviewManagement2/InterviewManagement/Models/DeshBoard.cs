using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewManagement.Models
{
	public class DeshBoard
	{
		public long TotalCompany { get; set; }
		public long LoginEmployee { get; set; }
		public long LoginCandidate { get; set; }
		public long TodayInterview { get; set; }
	}
}