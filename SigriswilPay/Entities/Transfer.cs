using SigriswilPay.DTO;

namespace SigriswilPay.Entities;

public class Transfer
{
    public string Id { get; private set; }
    public string Payer { get; private set; }
    public string Payee { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime CreatedAt { get; private set; }
    
    protected Transfer() {}
    
    public Transfer(CreateTransfer createTransferDTO)
    {
        Id = Guid.NewGuid().ToString("N");
        CreatedAt = DateTime.UtcNow;
        Payer = createTransferDTO.Payer ?? throw new ArgumentNullException(nameof(createTransferDTO.Payer));
        Payee = createTransferDTO.Payee ?? throw new ArgumentNullException(nameof(createTransferDTO.Payee));
        Amount = createTransferDTO.Amount >= 0 ? createTransferDTO.Amount : throw new Exception("Cannot create a user with a balance less than zero");
    }
}