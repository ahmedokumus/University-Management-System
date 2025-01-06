using System.Data.Entity.Migrations;
using System.Web.Mvc;
using Web_Tasarim.Models;
using System.Linq;

namespace Web_Tasarim.Controllers
{
    [Authorize(Roles = "4")]
    public class StudentController : Controller
    {
        // GET: Student

        private Context context = new Context();

        public ActionResult ExamResults()
        {
            var username = (string)Session["StudentUsername"];
            var id = context.Students.Where(x => x.Username == username).Select(y => y.StudentId).FirstOrDefault();
            var datums = context.StudentCourses.Where(x => x.StudentId == id);
            return View(datums.ToList());
        }

        public ActionResult Courses()
        {
            var username = (string)Session["StudentUsername"];
            var departmentId = context.Students.Where(x => x.Username == username).Select(y => y.DepartmentId).FirstOrDefault();
            var datums = context.Courses.Where(x => x.DepartmentId == departmentId);
            
            var courseId = context.Courses.Where(x => x.DepartmentId == departmentId).Select(y => y.CourseId)
                .FirstOrDefault();
            ViewBag.courseId = courseId;

            return View(datums.ToList());
        }
        public ActionResult CourseAdd(int id)
        {
            var username = (string)Session["StudentUsername"];
            var data = context.Courses.FirstOrDefault(x => x.CourseId == id);
            var student = context.Students.FirstOrDefault(x => x.Username == username);

            context.StudentCourses.AddOrUpdate(new StudentCourse()
            {
                CourseId = data.CourseId,
                StudentId = student.StudentId
            });
            context.SaveChanges();
            return View("Courses");
        }
    }
}