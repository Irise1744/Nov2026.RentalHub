using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Nov2026.Database.EfAppDbContextModels;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Lease> Leases { get; set; }

    public virtual DbSet<LeaseTenant> LeaseTenants { get; set; }

    public virtual DbSet<Owner> Owners { get; set; }

    public virtual DbSet<Property> Properties { get; set; }

    public virtual DbSet<RentPayment> RentPayments { get; set; }

    public virtual DbSet<Tenant> Tenants { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Lease>(entity =>
        {
            entity.HasKey(e => e.LeaseId).HasName("PK__Leases__21FA58C1E53C3B1C");

            entity.HasIndex(e => e.PropertyId, "UX_Leases_OneActiveLeasePerProperty")
                .IsUnique()
                .HasFilter("([Status]='Active')");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.MonthlyRent).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PaymentDueDay).HasDefaultValue((byte)1);
            entity.Property(e => e.SecurityDeposit).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Pending");

            entity.HasOne(d => d.Property).WithOne(p => p.Lease)
                .HasForeignKey<Lease>(d => d.PropertyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Leases_Properties");
        });

        modelBuilder.Entity<LeaseTenant>(entity =>
        {
            entity.HasKey(e => new { e.LeaseId, e.TenantId });

            entity.HasOne(d => d.Lease).WithMany(p => p.LeaseTenants)
                .HasForeignKey(d => d.LeaseId)
                .HasConstraintName("FK_LeaseTenants_Leases");

            entity.HasOne(d => d.Tenant).WithMany(p => p.LeaseTenants)
                .HasForeignKey(d => d.TenantId)
                .HasConstraintName("FK_LeaseTenants_Tenants");
        });

        modelBuilder.Entity<Owner>(entity =>
        {
            entity.HasKey(e => e.OwnerId).HasName("PK__Owners__819385B877514C03");

            entity.HasIndex(e => e.Email, "UQ__Owners__A9D105342DC84C38").IsUnique();

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(30);
        });

        modelBuilder.Entity<Property>(entity =>
        {
            entity.HasKey(e => e.PropertyId).HasName("PK__Properti__70C9A7357690EAD1");

            entity.Property(e => e.AddressLine1).HasMaxLength(200);
            entity.Property(e => e.AddressLine2).HasMaxLength(200);
            entity.Property(e => e.Bathrooms).HasColumnType("decimal(3, 1)");
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.Country).HasMaxLength(100);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.IsAvailable).HasDefaultValue(true);
            entity.Property(e => e.MonthlyRent).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PostalCode).HasMaxLength(20);
            entity.Property(e => e.PropertyType).HasMaxLength(30);
            entity.Property(e => e.StateProvince).HasMaxLength(100);
            entity.Property(e => e.Title).HasMaxLength(200);

            entity.HasOne(d => d.Owner).WithMany(p => p.Properties)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Properties_Owners");
        });

        modelBuilder.Entity<RentPayment>(entity =>
        {
            entity.HasKey(e => e.RentPaymentId).HasName("PK__RentPaym__1578A94285747A9A");

            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.PaymentMethod).HasMaxLength(30);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Pending");

            entity.HasOne(d => d.Lease).WithMany(p => p.RentPayments)
                .HasForeignKey(d => d.LeaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RentPayments_Leases");
        });

        modelBuilder.Entity<Tenant>(entity =>
        {
            entity.HasKey(e => e.TenantId).HasName("PK__Tenants__2E9B47E13C87FC8F");

            entity.HasIndex(e => e.Email, "UQ__Tenants__A9D10534D4A1F638").IsUnique();

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
