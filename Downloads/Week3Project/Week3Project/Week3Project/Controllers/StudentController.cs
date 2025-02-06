using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Week3Project.Models;

namespace Week3Project.Controllers
{
    public class StudentController : LibrarianController
    {
        // GET: Student

        public ActionResult StudentLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult StudentLogin(StudentLoginModel student)
        {
            var findUsername = students.Find(x => x.Username == student.Username);
            if (findUsername != null)
            {
                if (student.Password == findUsername.Password)
                {
                    return RedirectToAction("StudentDashBoard");
                }
                else
                {
                    TempData["Message"] = "Wrong Password";
                    return View();
                }
            }
            TempData["Message"] = "Student with this name does not Exist";
            return View("StudentLogin", student);
        }

        public ActionResult StudentDashBoard()
        {
            return View("StudentDashBoard");
        }

        public ActionResult StudentReport()
        {

            var firstStudents = students.FirstOrDefault();

            if (firstStudents != null)
            {
                return View(firstStudents);
            }
            else
            {
                TempData["Message"] = "No students found";
                return RedirectToAction("StudentLogin");
            }
        }
        public ActionResult BookReport()
        {

            var firstStudent = issueDate.FirstOrDefault();

            if (firstStudent != null)
            {
                return View(firstStudent);
            }
            else
            {
                TempData["Message"] = "No book found";
                return RedirectToAction("StudentLogin");
            }
        }
    }
}



