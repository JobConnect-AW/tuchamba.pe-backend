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
        builder.Entity<Proposal>().Property(p => p.WorkerUid).IsRequired();
        builder.Entity<Proposal>().Property(p => p.CustomerUid).IsRequired();
        builder.Entity<Proposal>().Property(p => p.Title).IsRequired();
        builder.Entity<Proposal>().Property(p => p.Description).IsRequired();
        builder.Entity<Proposal>().Property(p => p.Price).IsRequired();
        builder.Entity<Proposal>().Property(p => p.EstimatedTime).IsRequired();
        builder.Entity<Proposal>().Property(p => p.Status).IsRequired();
        builder.Entity<Proposal>().Property(p => p.SubmittedAt).IsRequired();
    }
}