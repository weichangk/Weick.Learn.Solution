using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiAjaxCRUD.Models;

namespace WebApiAjaxCRUD.Controllers
{
    public class EmployeeController : ApiController
    {
        Models.WebApiAjaxCRUDEntities db = new Models.WebApiAjaxCRUDEntities();

        // GET api/EmployeesAPI
        [Route("api/EmployeesAPI")]
        public IEnumerable<Employee> GetEmployees()
        {
            return db.Employees.AsEnumerable();
        }

        // GET api/EmployeesAPI/5
        [Route("api/EmployeesAPI/{id}")]
        public Employee GetEmployee(int id)
        {
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return employee;
        }

        // PUT api/EmployeesAPI/5
        [Route("api/EmployeesAPI")]
        public IHttpActionResult PutEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/EmployeesAPI
        [Route("api/EmployeesAPI")]
        public IHttpActionResult PostEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE api/EmployeesAPI/5
        [Route("api/EmployeesAPI/{id}")]
        public IHttpActionResult DeleteEmployee(int id)
        {
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            db.Employees.Remove(employee);
            db.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
