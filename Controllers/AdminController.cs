using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Web_Tasarim.Models;

namespace Web_Tasarim.Controllers
{
    [Authorize(Roles = "1")]
    public class AdminController : Controller
    {
        // GET: Admin
        private Context context = new Context();

        public ActionResult Index()
        {
            var faculties = from faculty in context.Faculties select faculty;
            ViewBag.facultyCount = faculties.Count();

            var departments = from department in context.Departments select department;
            ViewBag.departmentCount = departments.Count();

            var courses = from course in context.Courses select course;
            ViewBag.courseCount = courses.Count();

            var instructors = from instructor in context.Instructors select instructor;
            ViewBag.instructorCount = instructors.Count();

            var username = (string)Session["AdminUsername"];
            var datums = context.Admins.FirstOrDefault(x => x.Username == username);
            return View(datums);
        }

        public ActionResult FacultyList()
        {
            var faculties = from faculty in context.Faculties select faculty;
            return View(faculties.ToList());
        }

        [HttpGet]
        public ActionResult NewFaculty()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewFaculty(Faculty faculty)
        {
            context.Faculties.Add(faculty);
            context.SaveChanges();
            return RedirectToAction("FacultyList");
        }


        public ActionResult DepartmentList()
        {
            var departments = from department in context.Departments select department;
            return View(departments.ToList());
        }

        [HttpGet]
        public ActionResult NewDepartment()
        {
            List<SelectListItem> deger1 = (from faculty in context.Faculties.ToList()
                                           select new SelectListItem
                                           {
                                               Text = faculty.FacultyName,
                                               Value = faculty.FacultyId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult NewDepartment(Department department)
        {
            context.Departments.Add(department);
            context.SaveChanges();
            return RedirectToAction("DepartmentList");
        }


        public ActionResult CourseList()
        {
            var courses = from course in context.Courses select course;
            return View(courses.ToList());
        }

        [HttpGet]
        public ActionResult NewCourse()
        {
            List<SelectListItem> deger1 = (from department in context.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = department.Faculty.FacultyName + " → " + department.DepartmentName,
                                               Value = department.DepartmentId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult NewCourse(Course course)
        {
            context.Courses.Add(course);
            context.SaveChanges();
            return RedirectToAction("CourseList");
        }


        public ActionResult InstructorList()
        {
            var instructors = from instructor in context.Instructors select instructor;
            return View(instructors.ToList());
        }

        [HttpGet]
        public ActionResult NewInstructor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewInstructor(Instructor instructor)
        {
            instructor.Role = 3;
            context.Instructors.Add(instructor);
            context.SaveChanges();
            return RedirectToAction("InstructorList");
        }

        public ActionResult StudentList()
        {
            var students = from student in context.Students select student;
            return View(students.ToList());
        }
    }
}