using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.ComponentModel.DataAnnotations;

namespace MvcfirstApplication1.Controllers
{
    public class EmployeeValidations
    {
        [Required(ErrorMessage = "Name field is required")]
        public String empname { get; set; }

        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [Required(ErrorMessage = "Emailid feild is required")]
        public string Emailid { get; set; }

        [Required(ErrorMessage = "Password feild is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Address feild is required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public string gender { get; set; }

        [Required(ErrorMessage = "Salary feild is required")]
        public string salary { get; set; }

        [Range(5, 50)]
        [Required(ErrorMessage = "Age feild is required")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Empoly id required.")]
        public int empid { get; set; }
        [Display(Name = "Mobile Number:")]
        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string Contact { get; set; }
    }
}