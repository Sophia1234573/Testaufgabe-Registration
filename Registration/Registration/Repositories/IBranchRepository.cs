using Registration.Models.Domain;

namespace Registration.Repositories
{
    public interface IBranchRepository
    {
        Task<List<Branch>> GetAllAsync();
        Task<Branch?> GetByIdAsync(Guid id);    
        Task<Branch> CreateAsync(Branch branch); 
        Task<Branch?> UpdateAsync(Guid id, Branch branch);
        Task<Branch?> DeleteAsync(Guid id);
        Task<Branch?> GetByNameAsync(string name);
    }
}
