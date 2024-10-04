using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InterviewManagement.Models
{
    public class Employeshow
    {
       
        public long EmployeeId { get; set; }
        public long CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfJoining { get; set; }
       
        public string Password { get; set; }
        public string EmailId { get; set; }
        public int ManagerId { get; set; }

        // Additional Properties
        public string RollName { get; set; }
        public string Department { get; set; }
        

    }
}