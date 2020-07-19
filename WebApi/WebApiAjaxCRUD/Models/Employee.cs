using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiAjaxCRUD.Models
{
    public class Employee
    {
        public Employee()
        {

        }
        [Key]
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public Nullable<int> Age { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}