﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SigriswilPay.Data;

#nullable disable

namespace SigriswilPay.Migrations
{
    [DbContext(typeof(AppDataContext))]
    [Migration("20231128205124_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SigriswilPay.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(40)")
                        .HasColumnName("Id");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18.2)")
                        .HasColumnName("Balance");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Email");

                    b.Property<string>("IdentificationNumber")
                        .IsRequired()
                        .HasColumnType("varchar(15)")
                        .HasColumnName("IdentificationNumber");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Name");

                    b.Property<int>("Type")
                        .HasColumnType("int")
                        .HasColumnName("UserType");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("IdentificationNumber")
                        .IsUnique();

                    b.ToTable("Users", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
