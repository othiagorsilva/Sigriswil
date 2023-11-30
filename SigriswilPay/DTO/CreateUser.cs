using System.ComponentModel.DataAnnotations;
using SigriswilPay.Entities;

namespace SigriswilPay.DTO;

public class CreateUser
{
    [Required]
    public UserType Type { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string IdentificationNumber { get; set; }
    
    [Required]
    public string Email { get; set; }
    
    [Required]
    public decimal Balance { get; set; }
}