namespace TuChambaPe.Payments.Interfaces.REST.Resources;

/// <summary>
///     Create payment resource for REST API
/// </summary>
/// <param name="Uid">The unique identifier for the payment</param>
/// <param name="OfferUid">The offer UID for the payment</param>
/// <param name="Amount">The payment amount</param>
/// <param name="Currency">The payment currency</param>
public record CreatePaymentResource(Guid Uid, Guid OfferUid, decimal Amount, string Currency); 