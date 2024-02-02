using Microsoft.EntityFrameworkCore;
using Registration.Data;
using Registration.Models.Domain;

namespace Registration.Repositories
{
    public class SQLBranchRepository : IBranchRepository
    {
        private readonly RegistrationDbContext dbContext;
        public SQLBranchRepository(RegistrationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Branch> CreateAsync(Branch branch)    
        {
            await dbContext.Branches.AddAsync(branch);
            await dbContext.SaveChangesAsync();

            return branch;
        }

        public async Task<Branch?> DeleteAsync(Guid id)
        {
            var existingBranch = await dbContext.Branches.FirstOrDefaultAsync(x => x.Id == id);

            if (existingBranch == null) 
            {
                return null;
            }

            dbContext.Branches.Remove(existingBranch);
            await dbContext.SaveChangesAsync();

            return existingBranch;
        }

        public async Task<List<Branch>> GetAllAsync()
        {
            return await dbContext.Branches.ToListAsync();
        }

        public async Task<Branch?> GetByIdAsync(Guid id)
        {
            return await dbContext.Branches.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Branch?> GetByNameAsync(string name)
        {
            return await dbContext.Branches.FirstOrDefaultAsync(b => b.Name == name);
        }

        public async Task<Branch?> UpdateAsync(Guid id, Branch branch)
        {
            var existingBranch = await dbContext.Branches.FirstOrDefaultAsync(x => x.Id == id);

            if (existingBranch == null)
            {
                return null;
            }

            existingBranch.Name = branch.Name;

            await dbContext.SaveChangesAsync();
            return existingBranch;
        }
    }
}
