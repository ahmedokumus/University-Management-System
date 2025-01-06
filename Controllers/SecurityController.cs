using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Web_Tasarim.Models;

namespace Web_Tasarim.Controllers
{
    [AllowAnonymous]
    public class SecurityController : Controller
    {
        // GET: Security
        private Context context = new Context();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Users users)
        {
            if (users.Role == 1)//Admin Login
            {
                var datums =
                    context.Admins.FirstOrDefault(x => x.Username == users.Username && x.Password == users.Password);
                if (datums != null)
                {
                    FormsAuthentication.SetAuthCookie(datums.Username, false);
                    Session["AdminUsername"] = datums.Username;
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ViewBag.error = "Kullanıcı adı veya şifre yanlış!";
                }
            }
            else if (users.Role == 2)//Officer Login
            {
                var datums =
                    context.Officers.FirstOrDefault(x => x.Username == users.Username && x.Password == users.Password);
                if (datums != null)
                {
                    FormsAuthentication.SetAuthCookie(datums.Username, false);
                    Session["OfficerUsername"] = datums.Username;
                    return RedirectToAction("CourseList", "Officer");
                }
                else
                {
                    ViewBag.error = "Kullanıcı adı veya şifre yanlış!";
                }
            }
            else if (users.Role == 3)//Öğr. Ele. Girişi
            {
                var datums =
                    context.Instructors.FirstOrDefault(x => x.Username == users.Username && x.Password == users.Password);
                if (datums != null)
                {
                    FormsAuthentication.SetAuthCookie(datums.Username, false);
                    Session["InstructorUsername"] = datums.Username;
                    return RedirectToAction("CourseList", "Instructor");
                }
                else
                {
                    ViewBag.error = "Kullanıcı adı veya şifre yanlış!";
                }
            }
            else if (users.Role == 4)//Öğrenci Girişi
            {
                var datums =
                    context.Students.FirstOrDefault(x => x.Username == users.Username && x.Password == users.Password);
                if (datums != null)
                {
                    FormsAuthentication.SetAuthCookie(datums.Username, false);
                    Session["StudentUsername"] = datums.Username;
                    return RedirectToAction("Courses", "Student");
                }
                else
                {
                    ViewBag.error = "Kullanıcı adı veya şifre yanlış!";
                }

            }
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Security");
        }
    }
}