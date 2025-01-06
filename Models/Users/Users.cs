namespace Web_Tasarim.Models
{
    public class Users
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public byte? Role { get; set; }
    }
}