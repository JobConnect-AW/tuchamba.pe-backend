using TuChambaPe.Payments.Domain.Model.ValueObjects;

namespace TuChambaPe.Payments.Domain.Model.Commands;

/// <summary>
///     Command to create a payment
/// </summary>
/// <param name="Uid">The unique identifier for the payment</param>
/// <param name="OfferUid">The offer UID for the payment</param>
/// <param name="Amount">The payment amount</param>
/// <param name="Currency">The payment currency</param>
public record CreatePaymentCommand(Guid Uid, OfferUid OfferUid, decimal Amount, string Currency); 