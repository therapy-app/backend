namespace backend.Models
{
    public abstract class UserBase
    {
        public string FullName { get; set; }
        public string EMail { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
    }
}
