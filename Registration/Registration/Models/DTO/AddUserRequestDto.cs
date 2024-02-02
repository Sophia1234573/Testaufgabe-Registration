using System.ComponentModel.DataAnnotations;
using Registration.Models.Domain;

namespace Registration.Models.DTO
{
    public class AddUserRequestDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
      //  [EmailAddress]
        public string? Email { get; set; }
        public CompanyDto? Company { get; set; }

        public string[] Roles { get; set; }
    }
}
