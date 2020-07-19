using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApiAjaxCRUD.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<WebApiAjaxCRUDEntities>
    {
        protected override void Seed(WebApiAjaxCRUDEntities context)
        {
            var Employees = new List<Employee>
            {
                new Employee { Name = "Rock" ,Age = 18, State = "shenzhen", Country = "China"},
                new Employee { Name = "james" ,Age = 18, State = "guangzhou", Country = "China"},
            };

            context.Employees.AddRange(Employees);
            base.Seed(context);
        }
    }
}