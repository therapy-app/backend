using System.ComponentModel.DataAnnotations;

namespace backend.Resources
{
    public class SignUpResource
    {
        [Required(ErrorMessage = "Full Name is required")]
        public string FullName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
