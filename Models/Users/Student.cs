using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web_Tasarim.Models
{
    public class Student : Users
    {
        [Key]
        public int StudentId { get; set; }
        public string ImageUrl { get; set; }

        public IEnumerable<StudentCourse> StudentCourses { get; set; }

        public int? DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}