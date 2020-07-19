using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApiAjaxCRUD.Models
{
    public class WebApiAjaxCRUDEntities: DbContext
    {
        public DbSet<Employee> Employees { get; set; }
    }
}