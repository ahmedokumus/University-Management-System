using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web_Tasarim.Models
{
    public class Instructor : Users
    {
        [Key]
        public int InstructorId { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}