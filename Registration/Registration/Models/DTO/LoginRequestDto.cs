using System.ComponentModel.DataAnnotations;

namespace Registration.Models.DTO
{
    public class LoginRequestDto
    {
        [Required]
        [DataType(DataType.Text)]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
