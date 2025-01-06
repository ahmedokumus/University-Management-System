using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Web_Tasarim.Models;

namespace Web_Tasarim.Controllers
{
    [Authorize(Roles = "2")]
    public class OfficerController : Controller
    {
        // GET: Officer
        private Context context = new Context();

        public ActionResult CourseList()
        {
            var courses = from course in context.Courses select course;
            return View(courses.ToList());
        }
        public ActionResult CourseRegister(int id)
        {
            List<SelectListItem> deger1 = (from x in context.Instructors.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Name + " " + x.Surname,
                                               Value = x.InstructorId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            var course = context.Courses.Find(id);
            return View("CourseRegister", course);
        }
        public ActionResult Register(Course course)
        {
            var item = context.Courses.Find(course.CourseId);
            item.InstructorId = course.InstructorId;
            context.SaveChanges();
            return RedirectToAction("CourseList");
        }

        public ActionResult StudentList()
        {
            var students = from student in context.Students select student;
            return View(students.ToList());
        }
        public ActionResult StudentUpgrade(int id)
        {
            List<SelectListItem> deger1 = (from item in context.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = item.DepartmentName,
                                               Value = item.DepartmentId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            var student = context.Students.Find(id);
            return View("StudentUpgrade", student);
        }
        public ActionResult Upgrade(Student student)
        {
            var item = context.Students.Find(student.StudentId);
            if (Request.Files.Count > 0 && student.ImageUrl == null)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string yol = "~/Content/UserImages/" + dosyaadi;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                student.ImageUrl = dosyaadi;
                item.Username = student.Username;
                item.ImageUrl = student.ImageUrl;
            }
            item.Name = student.Name;
            item.Surname = student.Surname;
            item.DepartmentId = student.DepartmentId;
            context.SaveChanges();
            return RedirectToAction("StudentList");
        }
        [HttpGet]
        public ActionResult NewStudent()
        {
            List<SelectListItem> deger1 = (from item in context.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = item.DepartmentName,
                                               Value = item.DepartmentId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            return View();
        }

        [HttpPost]
        public ActionResult NewStudent(Student student)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0]?.FileName);
                string yol = "~/Content/UserImages/" + dosyaadi;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                student.ImageUrl = dosyaadi;
            }
            context.Students.Add(student);
            student.Role = 4;
            context.SaveChanges();
            return RedirectToAction("StudentList", "Officer");
        }
    }
}