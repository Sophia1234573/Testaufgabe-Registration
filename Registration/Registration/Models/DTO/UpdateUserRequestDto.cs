using System.ComponentModel.DataAnnotations;

namespace Registration.Models.DTO
{
    public class UpdateUserRequestDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public Guid CompanyId { get; set; }
    }
}
