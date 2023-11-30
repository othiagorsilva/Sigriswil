using Microsoft.EntityFrameworkCore;
using SigriswilPay.Data.Configuration;
using SigriswilPay.Entities;

namespace SigriswilPay.Data;

public class AppDataContext : DbContext
{
    private string localConnStr = "Server=127.0.0.1;Database=DUOPAYDB;User Id=sa;Password=MyPass@word;Encrypt=False;TrustServerCertificate=True;";
    
    public AppDataContext()
    {
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Transfer> Transfers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(localConnStr);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration<User>(new UserConfiguration());
        modelBuilder.ApplyConfiguration<Transfer>(new TransferConfiguration());
    }
}