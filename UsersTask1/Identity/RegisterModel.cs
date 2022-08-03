using System.ComponentModel.DataAnnotations;
namespace UsersTask1.Identity
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "FisrtName is required")]
        public string FisrtName { get;  set; }

        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }
       
    }
}
