using System.ComponentModel.DataAnnotations;

namespace Registration.Models.DTO
{
    public class AddBranchRequestDto
    {
        [Required]
        public string Name { get; set; }
    }
}
