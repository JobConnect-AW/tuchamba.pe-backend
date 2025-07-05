using Microsoft.EntityFrameworkCore;
using TuChambaPe.Offers.Domain.Model.Aggregates;

namespace TuChambaPe.Offers.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyOffersConfiguration(this ModelBuilder builder)
    {
        // Offers Context

        builder.Entity<Offer>().HasKey(o => o.Id);
        builder.Entity<Offer>().Property(o => o.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Offer>().Property(o => o.Uid).IsRequired();
        builder.Entity<Offer>().HasIndex(o => o.Uid).IsUnique();
        builder.Entity<Offer>().Property(o => o.Title).IsRequired();
        builder.Entity<Offer>().Property(o => o.Description).IsRequired();
        builder.Entity<Offer>().Property(o => o.CategoryId).IsRequired();
        builder.Entity<Offer>().Property(o => o.Amount).IsRequired();
        builder.Entity<Offer>().Property(o => o.Duration).IsRequired();
        builder.Entity<Offer>().Property(o => o.PaymentMethod).IsRequired();
        builder.Entity<Offer>().Property(o => o.Status).IsRequired();
    }
}