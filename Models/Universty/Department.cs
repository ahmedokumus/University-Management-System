using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web_Tasarim.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public ICollection<Course> Courses { get; set; }

        public ICollection<Student> Students { get; set; }

        public int FacultyId { get; set; }
        public virtual Faculty Faculty { get; set; }
    }
}