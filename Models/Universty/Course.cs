using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Web_Tasarim.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }

        public IEnumerable<StudentCourse> StudentCourses { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public int? InstructorId { get; set; }
        public virtual Instructor Instructor { get; set; }
    }
}