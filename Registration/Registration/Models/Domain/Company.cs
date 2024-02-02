namespace Registration.Models.Domain
{
    public class Company
    {
        public Guid Id { get; set; }
        public string Name { get; set; }    
        public Guid BranchId { get; set; }

        public Branch Branch { get; set; }
    }
}
