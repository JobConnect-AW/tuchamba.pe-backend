using TuChambaPe.Payments.Domain.Model.Aggregates;
using TuChambaPe.Payments.Domain.Model.Queries;

namespace TuChambaPe.Payments.Domain.Services;

/// <summary>
///     Payment query service interface
/// </summary>
public interface IPaymentQueryService
{
    /// <summary>
    ///     Handle get payment by UID query
    /// </summary>
    /// <param name="query">The get payment by UID query</param>
    /// <returns>The payment if found, null otherwise</returns>
    Task<Payment?> Handle(GetPaymentByUidQuery query);

    /// <summary>
    ///     Handle get payments by offer UID query
    /// </summary>
    /// <param name="query">The get payments by offer UID query</param>
    /// <returns>Collection of payments for the offer</returns>
    Task<IEnumerable<Payment>> Handle(GetPaymentsByOfferUidQuery query);

    /// <summary>
    ///     Handle get all payments query
    /// </summary>
    /// <param name="query">The get all payments query</param>
    /// <returns>Collection of all payments</returns>
    Task<IEnumerable<Payment>> Handle(GetAllPaymentsQuery query);
} 