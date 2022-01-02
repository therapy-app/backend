using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<backend.Models.Tenant> Tenant { get; set; }
        public DbSet<backend.Models.Patient> Patient { get; set; }
        public DbSet<backend.Models.Employee> Employee { get; set; }
    }
}
