using Registration.Models.Domain;

namespace Registration.Repositories
{
    public interface ICompanyRepository
    {
        Task<Company> CreateAsync(Company company);
        Task<Company?> GetByCompanyAndBranchNameAsync(string companyName, string branchName); 
        Task<List<Company>> GetAllAsync();
        Task<Company?> GetByNameAsync(string name);
        Task<Company?> UpdateAsync(Guid id, Company сompany);
        Task<Company?> GetByIdAsync(Guid id);
        Task<Company?> DeleteAsync(Guid id);
    }
}
