namespace backend.Models
{
    public class Patient : ContactBase
    {
        public Guid Id { get; set; }
        public Guid TenantFK { get; set; }
        public string Diagnose { get; set; }
        public string TherapyCause { get; set; }
    }
}
