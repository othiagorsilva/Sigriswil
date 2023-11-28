using SigriswilPay.Entities;

namespace SigriswilPay.Interfaces.Repositories;

public interface IUserRepository
{
    Task<User> InsertOneAsync(User user);
    Task<IEnumerable<User>> GetAllAsync();
    Task<User?> GetOneByIdAsync(string id);
    Task<User?> GetOneByIdentificationNumberAsync(string identificationNumber);
    Task<User?> GetOneByEmailAsync(string email);
    Task<User> UpdateOneAsync(User user);
}