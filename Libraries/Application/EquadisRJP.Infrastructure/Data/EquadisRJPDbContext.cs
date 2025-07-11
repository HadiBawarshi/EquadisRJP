using EquadisRJP.Domain.Entities;
using EquadisRJP.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EquadisRJP.Infrastructure.Data;

public partial class EquadisRJPDbContext : DbContext, IUnitOfWork
{
    public EquadisRJPDbContext()
    {
    }

    public EquadisRJPDbContext(DbContextOptions<EquadisRJPDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CommercialOffer> CommercialOffers { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<OfferSubscription> OfferSubscriptions { get; set; }

    public virtual DbSet<Partnership> Partnerships { get; set; }

    public virtual DbSet<Retailer> Retailers { get; set; }

    public virtual DbSet<StoreType> StoreTypes { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CommercialOffer>(entity =>
        {
            entity.ToTable("CommercialOffer");

            entity.Property(e => e.Title).HasMaxLength(511);
            entity.Property(e => e.ValidFrom).HasColumnType("datetime");
            entity.Property(e => e.ValidTo).HasColumnType("datetime");

            entity.HasOne(d => d.Supplier).WithMany(p => p.CommercialOffers)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK_CommercialOffer_Supplier");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("Country");

            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<OfferSubscription>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("OfferSubscription");



            entity.HasOne(d => d.CommercialOffer).WithMany()
                .HasForeignKey(d => d.CommercialOfferId)
                .HasConstraintName("FK_OfferSubscription_CommercialOffer");

            entity.HasOne(d => d.Retailer).WithMany()
                .HasForeignKey(d => d.RetailerId)
                .HasConstraintName("FK_OfferSubscription_Retailer");
        });

        modelBuilder.Entity<Partnership>(entity =>
        {
            entity.ToTable("Partnership");

            entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

            entity.HasOne(d => d.Retailer).WithMany(p => p.Partnerships)
                .HasForeignKey(d => d.RetailerId)
                .HasConstraintName("FK_Partnership_Retailer");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Partnerships)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK_Partnership_Supplier");
        });

        modelBuilder.Entity<Retailer>(entity =>
        {
            entity.ToTable("Retailer");

            entity.Property(e => e.StoreName).HasMaxLength(511);
            entity.Property(e => e.UserId).HasMaxLength(450);

            entity.HasOne(d => d.StoreType).WithMany(p => p.Retailers)
                .HasForeignKey(d => d.StoreTypeId)
                .HasConstraintName("FK_Retailer_StoreType");
        });

        modelBuilder.Entity<StoreType>(entity =>
        {
            entity.ToTable("StoreType");

            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.ToTable("Supplier");

            entity.Property(e => e.CompanyName).HasMaxLength(255);
            entity.Property(e => e.UserId).HasMaxLength(450);

            entity.HasOne(d => d.Country).WithMany(p => p.Suppliers)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_Supplier_Country");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<EntityBase>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.UtcNow;
                    break;

                case EntityState.Modified:
                    entry.Entity.ModifiedDate = DateTime.UtcNow;
                    break;
            }
        }
        return await base.SaveChangesAsync(cancellationToken);

    }

}
