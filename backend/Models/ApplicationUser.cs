using Microsoft.AspNetCore.Identity;

namespace backend.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FullName { get; set; }
        public bool IsSuperUser { get; set; }
        public Guid TenantFK { get; set; }
        public OnboardingStatus OnboardingStatus { get; set; }
    }
    public enum OnboardingStatus
    {
        CREATED = 0,
        COMPLETED = 1
    }
}
