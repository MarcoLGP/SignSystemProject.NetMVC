using System.ComponentModel.DataAnnotations;

namespace SignSystemProject.Models
{
        public class SignUpResponse {
            
            [Required(ErrorMessage = "Campo de e-mail vazio")]
            [EmailAddress(ErrorMessage = "Digite um e-mail válido")]
            public string? Email;
            
            [Required(ErrorMessage = "Campo de nome vazio")]
            [MinLength(5, ErrorMessage = "Digite uma senha acima de 5 caracteres")]
            [MaxLength(40, ErrorMessage = "Digite uma senha com menos de 40 caracteres")]
            public string? Name;

            [Required(ErrorMessage = "Campo de senha vazio")]
            [MinLength(5, ErrorMessage = "Digite uma senha acima de 5 caracteres")]
            [MaxLength(40, ErrorMessage = "Digite uma senha com menos de 40 caracteres")]
            public string? Password;
        }
}