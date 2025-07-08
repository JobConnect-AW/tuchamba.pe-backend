namespace TuChambaPe.Payments.Domain.Model.Queries;

/// <summary>
///     Query to get a payment by UID
/// </summary>
/// <param name="PaymentUid">The payment UID to get</param>
public record GetPaymentByUidQuery(Guid PaymentUid); 