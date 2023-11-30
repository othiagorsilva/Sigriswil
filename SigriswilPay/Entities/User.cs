using SigriswilPay.DTO;

namespace SigriswilPay.Entities;

public class User
{
    public string Id { get; private set; }
    public UserType Type { get; private set; }
    public string Name { get; private set; }
    public string IdentificationNumber { get; private set; }
    public string Email { get; private set; }
    public decimal Balance { get; private set; }

    protected User() {}
    
    public User(CreateUser createUserDTO)
    {
        Id = Guid.NewGuid().ToString("N");
        Type = createUserDTO.Type;
        Name = createUserDTO.Name ?? throw new ArgumentNullException(nameof(createUserDTO.Name));
        IdentificationNumber = createUserDTO.IdentificationNumber ?? throw new ArgumentNullException(nameof(createUserDTO.IdentificationNumber));
        Email = createUserDTO.Email ?? throw new ArgumentNullException(nameof(createUserDTO.Email));
        Balance = createUserDTO.Balance >= 0 ? createUserDTO.Balance : throw new Exception("Cannot create a user with a balance less than zero");
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