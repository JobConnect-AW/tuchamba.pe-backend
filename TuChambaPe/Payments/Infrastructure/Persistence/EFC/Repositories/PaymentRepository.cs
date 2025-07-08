using TuChambaPe.Payments.Domain.Model.Aggregates;
using TuChambaPe.Payments.Domain.Model.ValueObjects;
using TuChambaPe.Payments.Domain.Repositories;
using TuChambaPe.Shared.Infrastructure.Persistence.EFC.Configuration;
using TuChambaPe.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace TuChambaPe.Payments.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
///     Payment repository implementation
/// </summary>
public class PaymentRepository(AppDbContext context) : BaseRepository<Payment>(context), IPaymentRepository
{
    /// <inheritdoc />
    public async Task<Payment?> FindByUidAsync(Guid uid)
    {
        return await Context.Set<Payment>()
            .FirstOrDefaultAsync(payment => payment.Uid == uid);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Payment>> FindByOfferUidAsync(OfferUid offerUid)
    {
        return await Context.Set<Payment>()
            .Where(payment => payment.OfferUid == offerUid)
            .ToListAsync();
    }

    /// <inheritdoc />
    public new async Task<IEnumerable<Payment>> ListAsync()
    {
        return await Context.Set<Payment>()
            .ToListAsync();
    }

    /// <inheritdoc />
    public new async Task AddAsync(Payment payment)
    {
        await Context.Set<Payment>().AddAsync(payment);
    }

    /// <inheritdoc />
    public new async Task UpdateAsync(Payment payment)
    {
        Context.Set<Payment>().Update(payment);
        await Task.CompletedTask;
    }

    /// <inheritdoc />
    public new async Task DeleteAsync(Payment payment)
    {
        Context.Set<Payment>().Remove(payment);
        await Task.CompletedTask;
    }
} 