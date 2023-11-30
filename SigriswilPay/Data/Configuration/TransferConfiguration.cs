using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SigriswilPay.Entities;

namespace SigriswilPay.Data.Configuration;

public class TransferConfiguration : IEntityTypeConfiguration<Transfer>
{
    public void Configure(EntityTypeBuilder<Transfer> builder)
    {
        builder.ToTable("Transfers");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .IsRequired()
            .HasColumnName("Id")
            .HasColumnType("varchar(40)");

        builder.Property(u => u.Payer)
            .IsRequired()
            .HasColumnName("Payer")
            .HasColumnType("varchar(40)");

        builder.Property(u => u.Payee)
            .IsRequired()
            .HasColumnName("Payee")
            .HasColumnType("varchar(40)");

        builder.Property(u => u.Amount)
            .IsRequired()
            .HasColumnName("Amount")
            .HasColumnType("decimal(18,2)");

        builder.Property(u => u.CreatedAt)
            .IsRequired()
            .HasColumnName("CreatedAt");
    }
}