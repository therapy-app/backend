namespace backend.Models
{
    public class Tenant
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid AdminUserFK { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Deleted { get; set; }
    }
}
