using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using WEBApiFinal1.Models;

namespace WEBApiFinal1.Controllers
{
    public class EmployeeController : ApiController
    {
        EmployeeEntities1 entity = new EmployeeEntities1();
        public IEnumerable<Employee> GetEmployees()
        {
            return entity.Employees.ToList();
        }
        public HttpResponseMessage Post([FromBody] Employee employee)
        {
            try
            {
                entity.Employees.Add(employee);
                entity.SaveChanges();
                var message = Request.CreateResponse(HttpStatusCode.Created, employee);
                message.Headers.Location = new Uri(Request.RequestUri + employee.Employee_Id.ToString());
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        public HttpResponseMessage Delete(int id)
        {
            var data = entity.Employees.SingleOrDefault(m => m.Employee_Id == id);
            if (data == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with id=" + id.ToString() + "not found to delete");
            }
            else
            {
                entity.Employees.Remove(data);
                entity.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Record deleted successfully");
            }
        }

        public HttpResponseMessage put(int id, [FromBody] Employee employee)
        {
            try
            {
                var data = entity.Employees.FirstOrDefault(e => e.Employee_Id == id);
                if (data == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with id=" + id.ToString() + "not found to update");
                }
                else
                {
                    data.First_Name = employee.First_Name;
                    data.Last_Name = employee.Last_Name;
                    data.Salary = employee.Salary;
                    data.Joing_Date = employee.Joing_Date;
                    data.Department = employee.Department;

                    entity.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}

