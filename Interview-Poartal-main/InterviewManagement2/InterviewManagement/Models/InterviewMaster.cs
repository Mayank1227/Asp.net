using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InterviewManagement.Models
{
	public class InterviewMaster
	{
	
		/// <summary>
		/// /
		/// </summary>
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		[Required]
		public string MobailNumber { get; set; }
		[Required]
		[DataType(DataType.Date)]
		public DateTime DOB { get; set; }
		[Required]
		public string Email { get; set; }
		[Required]
		public string Age { get; set; }
		[Required]
		public string Qualification { get; set; }
		[Required]
		public string Skill { get; set; }
		[Required]
		public string Experience { get; set; }
		[Required]
		public string Address { get; set; }
		[Required]
		public string Country { get; set; }
		[Required]
		public string State { get; set; }
		[Required]
		public string City { get; set; }
		

		//Additional Property

		public long CompanyId { get; set; }
		public string CompanyName { get; set; }
		public long CandidateId { get; set; }
		public int InterviewRound { get; set; }
		public string InterviewRoundName { get; set; }
		public string InterviewLocation { get; set; }

		[DataType(DataType.Date)]
		public DateTime InterviewDate { get; set; }
		public string EmployeeName { get; set; }
		public long EmployeeId { get; set; }
		public string InterViewStatus { get; set; }
		public long InProgressInterviewCount { get; set; }
		public int PendingCandidateCount { get; set; }
		public long InterviewDateCandite { get; set; }
		public long TotalPendingInterviewCount { get; set; }



	}
}