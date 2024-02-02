using Registration.Models.Domain;
using Registration.Data;
using Microsoft.EntityFrameworkCore;

namespace Registration.Repositories
{
    public class SQLCompanyRepository : ICompanyRepository
    {
        private readonly RegistrationDbContext dbContext;

        public SQLCompanyRepository(RegistrationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Company> CreateAsync(Company company)
        {
            await dbContext.Companies.AddAsync(company);
            await dbContext.SaveChangesAsync();
            return company;
        }

        public async Task<List<Company>> GetAllAsync()
        {
            return await dbContext.Companies.Include("Branch").ToListAsync();
        }

        public async Task<Company?> GetByNameAsync(string name)
        {
            return await dbContext.Companies.FirstOrDefaultAsync(c => c.Name == name);
        }

        public async Task<Company?> GetByCompanyAndBranchNameAsync(string companyName, string branchName)
        {
            return await dbContext.Companies
                .FirstOrDefaultAsync(c => c.Name == companyName && c.Branch.Name == branchName);
        }

        public async Task<Company?> UpdateAsync(Guid id, Company сompany)
        {
            var existingCompany = await dbContext.Companies.FirstOrDefaultAsync(x => x.Id == id);

            if (existingCompany == null)
            {
                return null;
            }

            existingCompany.Name = сompany.Name;
            existingCompany.BranchId = сompany.BranchId;

            await dbContext.SaveChangesAsync();
            return existingCompany;
        }

        public async Task<Company?> GetByIdAsync(Guid id)
        {
            return await dbContext.Companies.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Company?> DeleteAsync(Guid id)
        {
            var existingCompany = await dbContext.Companies.FirstOrDefaultAsync(x => x.Id == id);

            if (existingCompany == null)
            {
                return null;
            }

            dbContext.Companies.Remove(existingCompany);
            await dbContext.SaveChangesAsync();

            return existingCompany;
        }
    }
}
