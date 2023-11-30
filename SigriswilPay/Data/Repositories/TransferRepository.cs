using Microsoft.EntityFrameworkCore;
using SigriswilPay.Entities;
using SigriswilPay.Interfaces.Repositories;

namespace SigriswilPay.Data.Repositories;

public class TransferRepository : ITransferRepository
{
    private readonly AppDataContext _appDataContext;

    public TransferRepository(AppDataContext appDataContext)
    {
        _appDataContext = appDataContext;
    }

    public async Task<Transfer> InsertOneAsync(Transfer transfer)
    {
        await _appDataContext.Transfers.AddAsync(transfer);
        await _appDataContext.SaveChangesAsync();
        return transfer;
    }

    public async Task<IEnumerable<Transfer>> GetAllAsync() => await _appDataContext.Transfers.AsNoTracking()
        .ToListAsync();
}