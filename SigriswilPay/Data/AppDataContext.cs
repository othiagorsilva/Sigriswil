using Microsoft.EntityFrameworkCore;
using SigriswilPay.Data.Configuration;
using SigriswilPay.Entities;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace SigriswilPay.Data;

public class AppDataContext : DbContext
{
    public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
    {
            
    }
    
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration<User>(new UserConfiguration());
    }
}