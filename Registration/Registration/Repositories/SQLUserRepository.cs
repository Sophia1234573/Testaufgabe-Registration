using Microsoft.EntityFrameworkCore;
using Registration.Data;
using Registration.Models.Domain;

namespace Registration.Repositories
{
    public class SQLUserRepository : IUserRepository
    {
        private readonly RegistrationDbContext dbContext;

        public SQLUserRepository(RegistrationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<User> CreateAsync(User user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync(); 
            return user;    
        }

        public async Task<User?> DeleteAsync(Guid id)
        {
            var existingUser = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (existingUser == null)
            {
                return null;
            }

            dbContext.Users.Remove(existingUser);
            await dbContext.SaveChangesAsync();

            return existingUser;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await dbContext.Users.Include("Company").ToListAsync();
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await dbContext.Users
                .Include("Company")
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> IsUsernameUnique(string username)
        {
            var existingUser = await dbContext.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (existingUser == null)
            {
                return true;
            }
            return false;
        }

        public async Task<User?> UpdateAsync(Guid id, User user)
        {
            var existingUser = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);  

            if (existingUser == null) 
            {
                return null;
            }

            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;  
            existingUser.Username = user.Username;
            existingUser.Password = user.Password;
            existingUser.Email = user.Email;
            existingUser.CompanyId = user.CompanyId;

            await dbContext.SaveChangesAsync();

            return existingUser;
        }
    }
}
