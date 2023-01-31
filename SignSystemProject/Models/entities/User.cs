using System.ComponentModel.DataAnnotations;

namespace SignSystemProject.Models.entities
{
    public class User
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
