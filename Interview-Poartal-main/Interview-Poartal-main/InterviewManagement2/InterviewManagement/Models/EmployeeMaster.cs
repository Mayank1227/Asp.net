using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InterviewManagement.Models
{
    public class EmployeeMaster
    {
       
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }       
        public string MobileNo { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public string Password { get; set; }
        public string EmailId { get; set; }
        public int ManagerId { get; set; }
        public string EmployeeRoll { get; set; }       
        public string TypeName { get; set; }

        // Additional Properties

        public long EmployeeId { get; set; }
        public int IsActive { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public string CompanyName { get; set; }
        public long CompanyId { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfJoining { get; set; }
        public string Employee_F_L_D { get; set; }
        public long TotalEmployee { get; set; }
    }
}