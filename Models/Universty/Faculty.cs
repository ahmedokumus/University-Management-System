using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web_Tasarim.Models
{
    public class Faculty
    {
        [Key]
        public int FacultyId { get; set; }
        public string FacultyName { get; set; }

        public ICollection<Department> Departments { get; set; }
    }
}