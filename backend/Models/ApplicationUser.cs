using Microsoft.AspNetCore.Identity;

namespace backend.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FullName { get; set; }
        public SignUpStep SignUpStep { get; set; }
    }
    public enum SignUpStep
    {
        CREATED = 0,
        COMPLETED = 1
    }
}
