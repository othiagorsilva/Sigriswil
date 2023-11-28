namespace SigriswilPay.Entities;

public class User
{
    public string Id { get; private set; }
    public UserType Type { get; private set; }
    public string Name { get; private set; }
    public string IdentificationNumber { get; private set; }
    public string Email { get; private set; }
    public decimal Balance { get; private set; }

    public User(UserType type, string name, string identificationNumber, string email, decimal balance)
    {
        Id = Guid.NewGuid().ToString("N");
        Type = type;
        Name = name ?? throw new ArgumentNullException(nameof(name));
        IdentificationNumber = identificationNumber ?? throw new ArgumentNullException(nameof(identificationNumber));
        Email = email ?? throw new ArgumentNullException(nameof(email));
        Balance = balance >= 0 ? balance : throw new Exception("Cannot create a user with a balance less than zero");
    }

    public void Debit(decimal debitAmount)
    {
        throw new NotImplementedException();
    }

    public void Credit(decimal creditAmount)
    {
        throw new NotImplementedException();
    }
}