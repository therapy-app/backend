namespace backend.Models
{
    public class ContactBase
    {
        public string FullName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string EMail { get; set; }
    }
}
