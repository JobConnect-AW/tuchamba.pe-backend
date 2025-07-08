using TuChambaPe.Payments.Domain.Model.Aggregates;
using TuChambaPe.Payments.Domain.Model.ValueObjects;

namespace TuChambaPe.Payments.Domain.Repositories;

/// <summary>
///     Payment repository interface
/// </summary>
public interface IPaymentRepository
{
    /// <summary>
    ///     Find payment by UID
    /// </summary>
    /// <param name="uid">The payment UID</param>
    /// <returns>The payment if found, null otherwise</returns>
    Task<Payment?> FindByUidAsync(Guid uid);

    /// <summary>
    ///     Find payments by offer UID
    /// </summary>
    /// <param name="offerUid">The offer UID</param>
    /// <returns>Collection of payments for the offer</returns>
    Task<IEnumerable<Payment>> FindByOfferUidAsync(OfferUid offerUid);

    /// <summary>
    ///     Get all payments
    /// </summary>
    /// <returns>Collection of all payments</returns>
    Task<IEnumerable<Payment>> ListAsync();

    /// <summary>
    ///     Add a new payment
    /// </summary>
    /// <param name="payment">The payment to add</param>
    Task AddAsync(Payment payment);

    /// <summary>
    ///     Update an existing payment
    /// </summary>
    /// <param name="payment">The payment to update</param>
    Task UpdateAsync(Payment payment);

    /// <summary>
    ///     Delete a payment
    /// </summary>
    /// <param name="payment">The payment to delete</param>
    Task DeleteAsync(Payment payment);
} 