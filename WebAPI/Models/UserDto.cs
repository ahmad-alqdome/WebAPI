using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class UserDto  
    {
        [Key]
        public int userId { get; set; } 
        public string? Name { get; set; } 
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime BirthDay { get; set; }
        public string? Gender { get; set; }
        public string? Country { get; set; }
        public string? PhoneNumber { get; set; }


    }
}
