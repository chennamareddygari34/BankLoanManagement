using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BankLoanManagement.Models
{
    public partial class BankLoanApplicationContext : DbContext
    {
        public BankLoanApplicationContext()
        {
        }

        public BankLoanApplicationContext(DbContextOptions<BankLoanApplicationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; } = null!;
        public virtual DbSet<Loan> Loans { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:DevConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.FirstName).HasMaxLength(255);

                entity.Property(e => e.FullName).HasMaxLength(255);

                entity.Property(e => e.Gender).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(255);

                entity.Property(e => e.MaritalStatus).HasMaxLength(50);

                entity.Property(e => e.OccupationType).HasMaxLength(255);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK__Customer__Addres__4D94879B");
            });

            modelBuilder.Entity<CustomerAddress>(entity =>
            {
                entity.HasKey(e => e.AddressId)
                    .HasName("PK__Customer__091C2AFB9FAAA1B2");

                entity.ToTable("CustomerAddress");

                entity.Property(e => e.City).HasMaxLength(255);

                entity.Property(e => e.Country).HasMaxLength(255);

                entity.Property(e => e.District).HasMaxLength(255);

                entity.Property(e => e.HouseNo).HasMaxLength(255);

                entity.Property(e => e.Landmark).HasMaxLength(255);

                entity.Property(e => e.State).HasMaxLength(255);
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.ToTable("Loan");

                entity.Property(e => e.ApplicationDate).HasColumnType("datetime");

                entity.Property(e => e.ApprovalDate).HasColumnType("datetime");

                entity.Property(e => e.InterestRate).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.LoanAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.LoanDescription).HasMaxLength(255);

                entity.Property(e => e.LoanDocumentsVerified).HasDefaultValueSql("((0))");

                entity.Property(e => e.LoanStatus).HasMaxLength(255);

                entity.Property(e => e.LoanType).HasMaxLength(255);

                entity.Property(e => e.MaxLoanAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MonthlyPayment).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Loan_Customer");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserName).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
