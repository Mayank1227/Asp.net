using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InterviewManagement.Models
{
	public class ScheduleInterviewDB
	{

		public long CompanyId { get; set; }
		public long EmployeeId { get; set; }
		public long CandidateId { get; set; }
		public string InterviewEmail { get; set; }
		public string EmployeeName { get; set; }
		public int InterviewRound { get; set; }
		public string InterviewLocation { get; set; }

		[DataType(DataType.Date)]
		public DateTime InterviewDate { get; set; }

	}
}