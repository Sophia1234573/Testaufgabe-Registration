using Registration.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace Registration.Models.DTO
{
    public class AddCompanyRequestDto
    {
        [Required]
        public string Name { get; set; }
        public Guid BranchId { get; set; }
    }
}
