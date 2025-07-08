using Microsoft.EntityFrameworkCore;
using TuChambaPe.Payments.Infrastructure.Persistence.EFC.Configuration;

namespace TuChambaPe.Payments.Infrastructure.Persistence.EFC.Configuration.Extensions;

/// <summary>
///     Model builder extensions for Payments bounded context
/// </summary>
public static class ModelBuilderExtensions
{
    /// <summary>
    ///     Apply Payments configuration to the model builder
    /// </summary>
    /// <param name="modelBuilder">The model builder</param>
    public static void ApplyPaymentsConfiguration(this ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PaymentConfiguration());
    }
} 