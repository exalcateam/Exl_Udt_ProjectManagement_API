
using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Model
{
    public class Signuplogin
    {
        [Key]
        public int Id { get;set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }   
        public string Role { get; set; }
    }
}
