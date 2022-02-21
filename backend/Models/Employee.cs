namespace backend.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public Guid TenantFK { get; set; }
        public Guid UserFK { get; set; }
        public bool IsSuperUser { get; set; }
    }
}
