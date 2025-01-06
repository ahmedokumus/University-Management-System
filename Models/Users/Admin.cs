using System.ComponentModel.DataAnnotations;

namespace Web_Tasarim.Models
{
    public class Admin : Users
    {
        [Key] public int AdminId { get; set; }

    }
}