using Microsoft.EntityFrameworkCore;
using TuChambaPe.IAM.Domain.Model.Aggregates;

namespace TuChambaPe.IAM.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyIAMConfiguration(this ModelBuilder builder)
    {
        // IAM Context

        builder.Entity<Account>().HasKey(a => a.Id);
        builder.Entity<Account>().HasIndex(a => a.Uid).IsUnique();
        builder.Entity<Account>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Account>().Property(a => a.Uid).IsRequired();
        builder.Entity<Account>().Property(a => a.Email).IsRequired();
        builder.Entity<Account>().Property(a => a.PasswordHash).IsRequired();
    }
}