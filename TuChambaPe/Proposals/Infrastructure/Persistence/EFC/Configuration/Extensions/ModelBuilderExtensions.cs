using Microsoft.EntityFrameworkCore;
using TuChambaPe.Proposals.Domain.Model.Aggregates;

namespace TuChambaPe.Proposals.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyProposalsConfiguration(this ModelBuilder builder)
    {
        // Proposals Context

        builder.Entity<Proposal>().HasKey(p => p.Id);
        builder.Entity<Proposal>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Proposal>().Property(p => p.Uid).IsRequired();
        builder.Entity<Proposal>().HasIndex(p => p.Uid).IsUnique();
        builder.Entity<Proposal>().Property(p => p.OfferUid)
            .HasConversion(
                v => v.Value,
                v => new TuChambaPe.Proposals.Domain.Model.ValueObjects.OfferUid(v))
            .IsRequired();
        builder.Entity<Proposal>().Property(p => p.WorkerUid)
            .HasConversion(
                v => v.Value,
                v => new TuChambaPe.Proposals.Domain.Model.ValueObjects.WorkerUid(v))
            .IsRequired();
        builder.Entity<Proposal>().Property(p => p.Message).IsRequired();
        builder.Entity<Proposal>().Property(p => p.Price).IsRequired();
        builder.Entity<Proposal>().Property(p => p.Status).IsRequired();
        builder.Entity<Proposal>().Property(p => p.CreatedAt).IsRequired();
        builder.Entity<Proposal>().Property(p => p.UpdatedAt);
        builder.Entity<Proposal>().Property(p => p.CreatedBy);
        builder.Entity<Proposal>().Property(p => p.UpdatedBy);
    }
}