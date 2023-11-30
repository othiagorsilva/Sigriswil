using Microsoft.EntityFrameworkCore;
using SigriswilPay.Entities;
using SigriswilPay.Interfaces.Repositories;

namespace SigriswilPay.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDataContext _appDataContext;

    public UserRepository(AppDataContext appDataContext)
    {
        _appDataContext = appDataContext;
    }

    public async Task<User> InsertOneAsync(User user)
    {
        await _appDataContext.Users.AddAsync(user);
        await _appDataContext.SaveChangesAsync();
        return user;
    }

    public async Task<IEnumerable<User>> GetAllAsync() => await _appDataContext.Users.AsNoTracking()
        .ToListAsync();

    public async Task<User?> GetOneByIdAsync(string id) => await _appDataContext.Users.AsNoTracking()
        .FirstOrDefaultAsync(u => u.Id.Equals(id));

    public async Task<User?> GetOneByIdentificationNumberAsync(string identificationNumber) => await _appDataContext.Users.AsNoTracking()
        .FirstOrDefaultAsync(u => u.IdentificationNumber.Equals(identificationNumber));

    public async Task<User?> GetOneByEmailAsync(string email) => await _appDataContext.Users.AsNoTracking()
        .FirstOrDefaultAsync(u => u.Email.Equals(email));

    public async Task<User> UpdateOneAsync(User user)
    {
        _appDataContext.Users.Update(user);
        await _appDataContext.SaveChangesAsync();
        return user;
    }
}