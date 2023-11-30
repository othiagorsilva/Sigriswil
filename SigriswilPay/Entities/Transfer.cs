namespace SigriswilPay.Entities;

public class Transfer
{
    public string Id { get; private set; }
    public string Payer { get; private set; }
    public string Payee { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public Transfer()
    {
        
    }
}