using System.ComponentModel.DataAnnotations;

namespace Registration.Models.DTO
{
    public class UpdateCompanyRequestDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public Guid BranchId { get; set; }
    }
}
