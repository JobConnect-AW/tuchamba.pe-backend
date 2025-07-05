using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using TuChambaPe.Users.Domain.Model.Aggregates;

namespace TuChambaPe.Users.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyUsersConfiguration(this ModelBuilder builder)
    {
        // Users Context
        
        // User Configuration
        builder.Entity<User>().ToTable("users");
        builder.Entity<User>().HasKey(u => u.Id);
        builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(u => u.Uid).IsRequired().HasMaxLength(36);
        builder.Entity<User>().HasIndex(u => u.Uid).IsUnique();
        builder.Entity<User>().Property(u => u.AccountId).IsRequired();
        builder.Entity<User>().HasIndex(u => u.AccountId).IsUnique();
        builder.Entity<User>().Property(u => u.CustomerId).HasDefaultValue(null);
        builder.Entity<User>().Property(u => u.WorkerId).HasDefaultValue(null);
        
        // Customer Configuration
        builder.Entity<Customer>().ToTable("customers");
        builder.Entity<Customer>().HasKey(c => c.Id);
        builder.Entity<Customer>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Customer>().Property(c => c.Uid).IsRequired().HasMaxLength(36);
        builder.Entity<Customer>().HasIndex(c => c.Uid).IsUnique();
        builder.Entity<Customer>().Property(c => c.FirstName).IsRequired().HasMaxLength(100);
        builder.Entity<Customer>().Property(c => c.LastName).IsRequired().HasMaxLength(100);
        builder.Entity<Customer>().Property(c => c.Phone).IsRequired().HasMaxLength(20);
        builder.Entity<Customer>().Property(c => c.ProfileType).IsRequired().HasMaxLength(50);
        builder.Entity<Customer>().Property(c => c.Location).IsRequired().HasMaxLength(255);
        builder.Entity<Customer>().HasIndex(c => c.Location);
        builder.Entity<Customer>().Property(c => c.Bio).HasMaxLength(1000);
        builder.Entity<Customer>().Property(c => c.IsVerified).IsRequired().HasDefaultValue(false);
        builder.Entity<Customer>().Property(c => c.CreatedAt).IsRequired();
        builder.Entity<Customer>().Property(c => c.UpdatedAt).IsRequired();
        
        // Worker Configuration
        builder.Entity<Worker>().ToTable("workers");
        builder.Entity<Worker>().HasKey(w => w.Id);
        builder.Entity<Worker>().Property(w => w.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Worker>().Property(w => w.Uid).IsRequired().HasMaxLength(36);
        builder.Entity<Worker>().HasIndex(w => w.Uid).IsUnique();
        builder.Entity<Worker>().Property(w => w.FirstName).IsRequired().HasMaxLength(100);
        builder.Entity<Worker>().Property(w => w.LastName).IsRequired().HasMaxLength(100);
        builder.Entity<Worker>().Property(w => w.Phone).IsRequired().HasMaxLength(20);
        builder.Entity<Worker>().Property(w => w.Avatar).HasMaxLength(500);
        builder.Entity<Worker>().Property(w => w.ProfileType).IsRequired().HasMaxLength(50);
        builder.Entity<Worker>().Property(w => w.Location).IsRequired().HasMaxLength(255);
        builder.Entity<Worker>().HasIndex(w => w.Location);
        builder.Entity<Worker>().Property(w => w.Bio).HasMaxLength(1000);
        builder.Entity<Worker>().Property(w => w.Skills)
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null!),
                v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null!) ?? new List<string>())
            .HasColumnType("text");
        builder.Entity<Worker>().Property(w => w.Skills)
            .Metadata.SetValueComparer(new Microsoft.EntityFrameworkCore.ChangeTracking.ValueComparer<List<string>>(
                (c1, c2) => c1!.SequenceEqual(c2!),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToList()));
        builder.Entity<Worker>().Property(w => w.Experience).IsRequired();
        builder.Entity<Worker>().Property(w => w.Certifications)
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null!),
                v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null!) ?? new List<string>())
            .HasColumnType("text");
        builder.Entity<Worker>().Property(w => w.Certifications)
            .Metadata.SetValueComparer(new Microsoft.EntityFrameworkCore.ChangeTracking.ValueComparer<List<string>>(
                (c1, c2) => c1!.SequenceEqual(c2!),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToList()));
        builder.Entity<Worker>().Property(w => w.Rating).HasPrecision(3, 2).HasDefaultValue(0.0);
        builder.Entity<Worker>().Property(w => w.ReviewCount).IsRequired().HasDefaultValue(0);
        builder.Entity<Worker>().Property(w => w.IsVerified).IsRequired().HasDefaultValue(false);
        builder.Entity<Worker>().Property(w => w.Availability)
            .HasConversion(
                v => v != null ? JsonSerializer.Serialize(v, (JsonSerializerOptions)null!) : null,
                v => !string.IsNullOrEmpty(v) ? JsonSerializer.Deserialize<Dictionary<string, string>>(v, (JsonSerializerOptions)null!) : null)
            .HasColumnType("text");
        builder.Entity<Worker>().Property(w => w.Availability)
            .Metadata.SetValueComparer(new Microsoft.EntityFrameworkCore.ChangeTracking.ValueComparer<Dictionary<string, string>>(
                (c1, c2) => c1!.SequenceEqual(c2!),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.Key.GetHashCode(), v.Value.GetHashCode())),
                c => c.ToDictionary(kvp => kvp.Key, kvp => kvp.Value)));
        builder.Entity<Worker>().Property(w => w.YapeNumber).HasMaxLength(20);
        builder.Entity<Worker>().Property(w => w.PlinNumber).HasMaxLength(20);
        builder.Entity<Worker>().Property(w => w.BankAccountNumber).HasMaxLength(30);
        builder.Entity<Worker>().HasIndex(w => w.Rating);
        builder.Entity<Worker>().Property(w => w.CreatedAt).IsRequired();
        builder.Entity<Worker>().Property(w => w.UpdatedAt).IsRequired();
    }
}