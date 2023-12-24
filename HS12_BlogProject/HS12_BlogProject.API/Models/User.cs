using Microsoft.AspNetCore.Identity;

namespace HS12_BlogProject.API.Models
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }
    }
}
