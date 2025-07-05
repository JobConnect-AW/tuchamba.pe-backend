using Microsoft.EntityFrameworkCore;
using TuChambaPe.Reviews.Domain.Model.Aggregates;

namespace TuChambaPe.Reviews.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyReviewsConfiguration(this ModelBuilder builder)
    {
        builder.Entity<Review>().ToTable("reviews");
        builder.Entity<Review>().HasKey(r => r.Id);
        builder.Entity<Review>().Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Review>().Property(r => r.Uid).IsRequired().HasMaxLength(36);
        builder.Entity<Review>().HasIndex(r => r.Uid).IsUnique();
        builder.Entity<Review>().Property(r => r.ReceiverUserId).IsRequired();
        builder.Entity<Review>().HasIndex(r => r.ReceiverUserId);
        builder.Entity<Review>().Property(r => r.AuthorUserId).IsRequired();
        builder.Entity<Review>().HasIndex(r => r.AuthorUserId);
        builder.Entity<Review>().Property(r => r.Rating).IsRequired();
        builder.Entity<Review>().HasIndex(r => r.Rating);
        builder.Entity<Review>().Property(r => r.Comment).IsRequired().HasMaxLength(1000);
        builder.Entity<Review>().Property(r => r.CreatedAt).IsRequired();
        builder.Entity<Review>().Property(r => r.UpdatedAt).IsRequired();
    }
}