using TuChambaPe.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using Microsoft.EntityFrameworkCore;
using TuChambaPe.IAM.Domain.Model.Aggregates;
using TuChambaPe.Offers.Domain.Model.Aggregates;
using TuChambaPe.Proposals.Domain.Model.Aggregates;

namespace TuChambaPe.Shared.Infrastructure.Persistence.EFC.Configuration
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {

        /// <summary>
        ///     On configuring the database context
        /// </summary>
        /// <remarks>
        ///     This method is used to configure the database context.
        ///     It also adds the created and updated date interceptor to the database context.
        /// </remarks>
        /// <param name="builder">
        ///     The option builder for the database context
        /// </param>
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            // builder.AddCreatedUpdatedInterceptor();
            base.OnConfiguring(builder);
        }

        /// <summary>
        ///     On creating the database model
        /// </summary>
        /// <remarks>
        ///     This method is used to create the database model for the application.
        /// </remarks>
        /// <param name="builder">
        ///     The model builder for the database context
        /// </param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // IAM Context

            builder.Entity<Account>().HasKey(a => a.Id);
            builder.Entity<Account>().HasIndex(a => a.Uid).IsUnique();
            builder.Entity<Account>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Account>().Property(a => a.Uid).IsRequired();
            builder.Entity<Account>().Property(a => a.Email).IsRequired();
            builder.Entity<Account>().Property(a => a.PasswordHash).IsRequired();

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

            builder.UseSnakeCaseNamingConvention();
        }
    }
}
