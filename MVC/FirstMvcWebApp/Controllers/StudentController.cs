using FirstMvcWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMvcWebApp.Controllers
{
    public class StudentController : Controller
    {
        static List<Student> StudentList;
        static StudentController()
        {
            StudentList = new List<Student>{
                            new Student() { StudentId = 1, StudentName = "John", Age = 18 } ,
                            new Student() { StudentId = 2, StudentName = "Steve",  Age = 21 } ,
                            new Student() { StudentId = 3, StudentName = "Bill",  Age = 25 } ,
                            new Student() { StudentId = 4, StudentName = "Ram" , Age = 20 } ,
                            new Student() { StudentId = 5, StudentName = "Ron" , Age = 31 } ,
                            new Student() { StudentId = 4, StudentName = "Chris" , Age = 17 } ,
                            new Student() { StudentId = 4, StudentName = "Rob" , Age = 19 }
                        };
        }


        // GET: Student
        public ActionResult Index()
        {
            return View(StudentList);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View(StudentList.Where(s => s.StudentId == id).SingleOrDefault());
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    Random rand = new Random();
                    var student = new Student()
                    {
                        StudentId = rand.Next(100),
                        StudentName = collection["StudentName"],
                        Age = int.Parse(collection["Age"]),
                    };
                    StudentList.Add(student);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            return View(StudentList.Where(s => s.StudentId == id).SingleOrDefault());
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    var student = StudentList.Where(s => s.StudentId == id).SingleOrDefault();
                    student.StudentName = collection["StudentName"];
                    student.Age = int.Parse(collection["Age"]);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Student/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteStudentById(int id)
        {
            try
            {
                // TODO: Add delete logic here
                StudentList.Remove(StudentList.First(s => s.StudentId == id));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
