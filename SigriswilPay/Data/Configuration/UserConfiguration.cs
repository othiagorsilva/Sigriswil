using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SigriswilPay.Entities;

namespace SigriswilPay.Data.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .IsRequired()
            .HasColumnName("Id")
            .HasColumnType("varchar(40)");

        builder.Property(u => u.Type)
            .IsRequired()
            .HasColumnName("UserType");

        builder.Property(u => u.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasColumnType("varchar(100)");

        builder.Property(u => u.IdentificationNumber)
            .IsRequired()
            .HasColumnName("IdentificationNumber")
            .HasColumnType("varchar(15)");

        builder.Property(u => u.Email)
            .IsRequired()
            .HasColumnName("Email")
            .HasColumnType("varchar(100)");

        builder.Property(u => u.Balance)
            .HasColumnName("Balance")
            .HasColumnType("decimal(18.2)");

        builder.HasIndex(u => u.IdentificationNumber).IsUnique();
        builder.HasIndex(u => u.Email).IsUnique();
    }
}