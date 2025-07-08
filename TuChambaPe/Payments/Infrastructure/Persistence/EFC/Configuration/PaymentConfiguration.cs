using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TuChambaPe.Payments.Domain.Model.Aggregates;
using TuChambaPe.Payments.Domain.Model.ValueObjects;

namespace TuChambaPe.Payments.Infrastructure.Persistence.EFC.Configuration;

/// <summary>
///     Payment entity configuration
/// </summary>
public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    /// <summary>
    ///     Configure Payment entity
    /// </summary>
    /// <param name="builder">The entity type builder</param>
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("payments");
        
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd()
            .HasColumnName("id");
        
        builder.Property(e => e.Uid)
            .IsRequired()
            .HasColumnName("uid");
        
        builder.Property(e => e.OfferUid)
            .HasConversion(
                offerUid => offerUid.Value,
                value => new OfferUid(value))
            .IsRequired()
            .HasColumnName("offer_uid");
        
        builder.Property(e => e.Amount)
            .HasColumnType("decimal(18,2)")
            .IsRequired()
            .HasColumnName("amount");
        
        builder.Property(e => e.Currency)
            .HasMaxLength(3)
            .IsRequired()
            .HasColumnName("currency");
        
        builder.Property(e => e.Status)
            .HasMaxLength(20)
            .IsRequired()
            .HasColumnName("status");
        
        builder.Property(e => e.CreatedDate)
            .IsRequired()
            .HasColumnName("created_at");
        
        builder.Property(e => e.UpdatedDate)
            .IsRequired()
            .HasColumnName("updated_at");
        
        builder.Property(e => e.WorkerVerified)
            .IsRequired()
            .HasColumnName("worker_verified");
        
        builder.Property(e => e.CustomerVerified)
            .IsRequired()
            .HasColumnName("customer_verified");
        
        // Indexes for better performance
        builder.HasIndex(e => e.Uid).IsUnique().HasDatabaseName("ix_payments_uid");
        builder.HasIndex(e => e.OfferUid).IsUnique().HasDatabaseName("ix_payments_offer_uid_unique");
        builder.HasIndex(e => e.Status).HasDatabaseName("ix_payments_status");
        builder.HasIndex(e => e.CreatedDate).HasDatabaseName("ix_payments_created_at");
    }
} 