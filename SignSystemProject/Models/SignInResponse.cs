using System.ComponentModel.DataAnnotations;

namespace SignSystemProject.Models
{
    public class SignInResponse
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
