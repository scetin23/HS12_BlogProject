using System.ComponentModel.DataAnnotations;

namespace HS12_BlogProject.API.Models
{
    public class UserForRegistrationDto
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        [Required(ErrorMessage = "username is required")]

        public string? UserName { get; set; }

        [Required(ErrorMessage = "password is required")]
        public string? Password { get; set; }
        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }
    }
}
