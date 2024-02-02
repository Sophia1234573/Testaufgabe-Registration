using System.ComponentModel.DataAnnotations;

namespace Registration.Models.DTO
{
    public class UpdateBranchRequestDto
    {
        [Required]
        public string Name { get; set; }
    }
}
