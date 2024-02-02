using Registration.Models.Domain;

namespace Registration.Models.DTO
{
    public class CompanyDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Branch? Branch { get; set; }
    }
}
