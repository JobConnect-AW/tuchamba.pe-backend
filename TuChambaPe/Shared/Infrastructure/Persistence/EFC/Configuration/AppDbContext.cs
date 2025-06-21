using TuChambaPe.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using Microsoft.EntityFrameworkCore;
using TuChambaPe.IAM.Domain.Model.Aggregates;

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

            builder.Entity<User>().HasKey(u => u.Id);
            builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(u => u.Uid).IsRequired();
            builder.Entity<User>().Property(u => u.Email).IsRequired();
            builder.Entity<User>().Property(u => u.PasswordHash).IsRequired();
            builder.UseSnakeCaseNamingConvention();
        }
    }
}
