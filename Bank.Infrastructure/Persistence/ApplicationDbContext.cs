using System;
using System.Collections.Generic;
using Bank.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bank.Infrastructure.Persistence;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AddressEntity> Addresses { get; set; }

    public virtual DbSet<CustomerEntity> Customers { get; set; }

    public virtual DbSet<CustomerStatusEntity> CustomerStatuses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AddressEntity>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("Address_PK");

            entity.ToTable("Address");

            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Number)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Postal_Code)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Postal-Code");
            entity.Property(e => e.Street)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CustomerEntity>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("Customer_PK");

            entity.ToTable("Customer");

            entity.Property(e => e.EmailAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationDateTime).HasColumnType("datetime");
            entity.Property(e => e.SecondName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Address).WithMany(p => p.Customers)
                .HasForeignKey(d => d.AddressID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Customer_Address_FK");

            entity.HasOne(d => d.CustomerStatus).WithMany(p => p.Customers)
                .HasForeignKey(d => d.CustomerStatusID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Customer_CustomerStatus_FK");
        });

        modelBuilder.Entity<CustomerStatusEntity>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("CustomerStatus_PK");

            entity.ToTable("CustomerStatus");

            entity.Property(e => e.StatusName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
