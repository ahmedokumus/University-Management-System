using System.Data.Entity;

namespace Web_Tasarim.Models
{
    public class Context : DbContext
    {
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Officer> Officers { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}