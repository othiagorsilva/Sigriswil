using SigriswilPay.Entities;

namespace SigriswilPay.Interfaces.Repositories;

public interface ITransferRepository
{
    Task<Transfer> InsertOneAsync(Transfer transfer);
    Task<IEnumerable<Transfer>> GetAllAsync();
}