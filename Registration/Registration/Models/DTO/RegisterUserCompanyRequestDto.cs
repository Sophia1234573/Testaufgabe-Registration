using Registration.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace Registration.Models.DTO
{
    public class RegisterUserCompanyRequestDto
    {
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public Guid CompanyId { get; set; }

        public string[] Roles { get; set; }
    }
}
