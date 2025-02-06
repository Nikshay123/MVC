using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Mvc;
using Week3Project.Models;

namespace Week3Project.Controllers
{
    public class LibrarianController : Controller
    {
        public static List<PublicationModel> publications = new List<PublicationModel>();
        protected static List<StudentReportModel> students = new List<StudentReportModel>();
        public static List<BookModel> books = new List<BookModel>();
        public static List<BranchModel> branches = new List<BranchModel>();
        public static List<IssueDateModel> issueDate = new List<IssueDateModel>();
        public static List<ReturnDateModel> returnDates = new List<ReturnDateModel>();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddPublication()
        {
            ViewBag.Branches = branches;
            return View();
        }

        [HttpPost]
        public ActionResult AddPublication(PublicationModel publication)
        {
            ViewBag.Branches = branches;

            if (ModelState.IsValid)
            {
                if (publications.Any(p => p.PublicationId == publication.PublicationId))
                {
                    TempData["ErrorMessage"] = "Publication with the same Id already exists.";
                }
                else
                {
                    publication.PublicationId = publications.Count + 1;


                    publications.Add(publication);
                    TempData["SuccessMessage"] = "Publication added successfully.";
                }
            }
            else
            {
                TempData["SuccessMessage"] = "Publication added successfully.";
            }

            return RedirectToAction("AddPublication", publication);
        }



        [HttpGet]
        public ActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(StudentReportModel student)
        {
            if (students.Any(s => s.Username == student.Username))
            {
                TempData["ErrorMessage"] = "Username already exists. Please choose a different username.";
                return View("AddStudent", student);
            }

            if (ModelState.IsValid)
            {
                student.Id = students.Count + 1;
                students.Add(student);
                TempData["SuccessMessage"] = "Student added successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to add student. Please check the form inputs.";
            }

            return View("AddStudent", student);
        }

        [HttpGet]
        public ActionResult AddStock()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStock(BookModel book)
        {
            if (ModelState.IsValid)
            {
                book.BookId = books.Count + 1;
                books.Add(book);
                TempData["SuccessMessage"] = "Stock added successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to add stock. Please check the form inputs.";
            }

            return View("AddStock", book);
        }

        [HttpGet]
        public ActionResult AddBranch()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBranch(BranchModel branch)
        {
            if (ModelState.IsValid)
            {
                branches.Add(branch);
                TempData["SuccessMessage"] = "Branch added successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to add branch. Please check the form inputs.";
            }

            return View("AddBranch", branch);
        }

        [HttpGet]
        public ActionResult IssueDate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IssueDate(IssueDateModel issue)
        {
            if (ModelState.IsValid)
            {
                issueDate.Add(issue);
                TempData["SuccessMessage"] = "IssueBook added successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to add issue date. Please check the form inputs.";
            }

            TempData["IssueDateList"] = issueDate; 

            return View("IssueDate", issue);
        }


        public ActionResult ReturnDate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ReturnDate(ReturnDateModel returnDate)
        {
            if (ModelState.IsValid)
            {
                returnDates.Add(returnDate);
                TempData["SuccessMessage"] = "Return Book added successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to add return date. Please check the form inputs.";
            }

            return View(returnDate);
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult LibraryLogin(LibrarionLoginModel login)
        {
            List<string> validUsernames = new List<string> { "Library", "AnotherUser" };
            List<string> validPasswords = new List<string> { "LibraryPassword", "AnotherPassword" };

            if (validUsernames.Contains(login.Username) && validPasswords.Contains(login.Password))
            {
                return RedirectToAction("DashBoard");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid username or password.";
                return View("LibraryLogin", login);
            }
        }

        public ActionResult DashBoard()
        {
            DashBoard viewModel = new DashBoard
            {
                Publications = publications,
                Students = students,
                Books = books,
                Branches = branches,
                IssueDates = issueDate,
                ReturnDates = returnDates
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult DashBoard(DashBoard dashBoard)
        {
            return View("DashBoard", dashBoard);
        }
    }
}
