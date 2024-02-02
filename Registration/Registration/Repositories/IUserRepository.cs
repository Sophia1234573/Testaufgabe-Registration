using Registration.Models.Domain;

namespace Registration.Repositories
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User user);
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(Guid id);
        Task<User?> UpdateAsync(Guid id, User user); 
        Task<User?> DeleteAsync(Guid id);
        Task<bool> IsUsernameUnique(string username);
    }
}
