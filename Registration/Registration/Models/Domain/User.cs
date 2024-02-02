namespace Registration.Models.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }    
        public string? Email { get; set; }
        public Guid CompanyId { get; set; } 

        public Company Company { get; set; }
    }
}
