namespace SigriswilPay.DTO;

public class CreateTransfer
{
    public string Payer { get; set; }
    public string Payee { get; set; }
    public decimal Amount { get; set; }
}