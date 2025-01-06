using System.ComponentModel.DataAnnotations;

namespace Web_Tasarim.Models
{
    public class Officer : Users
    {
        [Key]
        public int OfficerId { get; set; }
    }
}