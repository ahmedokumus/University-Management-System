using System.Linq;
using System.Web.Mvc;
using Web_Tasarim.Models;

namespace Web_Tasarim.Controllers
{
    [Authorize(Roles = "3")]
    public class InstructorController : Controller
    {
        // GET: Instructor
        private Context context = new Context();

        public ActionResult CourseList()
        {
            var username = (string)Session["InstructorUsername"];
            var id = context.Instructors.Where(x => x.Username == username).Select(y => y.InstructorId).FirstOrDefault();
            var datums = context.Courses.Where(x => x.InstructorId == id);
            return View(datums.ToList());
        }

        public ActionResult StudentList(int id)
        {
            var students = context.StudentCourses.Where(x => x.CourseId == id).ToList();
            ViewBag.ders = context.Courses.FirstOrDefault(x => x.CourseId == id).CourseName;
            return View(students);
        }

        [HttpGet]
        public ActionResult EnterResult(int id)
        {
            var students = context.StudentCourses.FirstOrDefault(x => x.Id == id);
            return View(students);
        }
        [HttpPost]
        public ActionResult EnterResult(StudentCourse studentCourse)
        {
            var item = context.StudentCourses.Find(studentCourse.Id);
            item.Vize = studentCourse.Vize;
            item.Final = studentCourse.Final;
            context.SaveChanges();
            return RedirectToAction("CourseList");
        }
    }
}