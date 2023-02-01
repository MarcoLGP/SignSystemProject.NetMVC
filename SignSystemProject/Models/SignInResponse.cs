using System.ComponentModel.DataAnnotations;

namespace SignSystemProject.Models
{
    public class SignInResponse
    {
        [Required(ErrorMessage = "Campo de E-mail vazio")]
        [EmailAddress(ErrorMessage = "Digite um e-mail válido")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Campo de senha vazio")]
        public string? Password { get; set; }
    }
}
