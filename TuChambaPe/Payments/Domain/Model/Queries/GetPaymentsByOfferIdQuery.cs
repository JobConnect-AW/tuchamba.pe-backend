using TuChambaPe.Payments.Domain.Model.ValueObjects;

namespace TuChambaPe.Payments.Domain.Model.Queries;

/// <summary>
///     Query to get payments by offer UID
/// </summary>
/// <param name="OfferUid">The offer UID to get payments for</param>
public record GetPaymentsByOfferUidQuery(OfferUid OfferUid); 