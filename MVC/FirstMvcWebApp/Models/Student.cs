using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirstMvcWebApp.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Please enter student name.")]
        public string StudentName { get; set; }

        [Range(5, 50)]
        public int Age { get; set; }
    }
}