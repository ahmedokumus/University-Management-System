using System.ComponentModel.DataAnnotations;

namespace Web_Tasarim.Models
{
    public class StudentCourse
    {
        [Key]
        public int Id { get; set; }

        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        public int? CourseId { get; set; }
        public virtual Course Course { get; set; }

        public byte? Vize { get; set; }
        public byte? Final { get; set; }
    }
}