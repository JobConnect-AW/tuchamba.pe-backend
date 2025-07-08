namespace TuChambaPe.Payments.Interfaces.REST.Resources;

/// <summary>
///     Payment resource for REST API
/// </summary>
/// <param name="Uid">The unique identifier of the payment</param>
/// <param name="OfferUid">The offer UID for the payment</param>
/// <param name="Amount">The payment amount</param>
/// <param name="Currency">The payment currency</param>
/// <param name="Status">The payment status</param>
/// <param name="CreatedAt">The payment creation date</param>
/// <param name="UpdatedAt">The payment last update date</param>
/// <param name="WorkerVerified">Whether the payment is verified by worker</param>
/// <param name="CustomerVerified">Whether the payment is verified by customer</param>
public record PaymentResource(
    Guid Uid, 
    Guid OfferUid,
    decimal Amount, 
    string Currency, 
    string Status, 
    DateTimeOffset? CreatedAt, 
    DateTimeOffset? UpdatedAt, 
    bool WorkerVerified, 
    bool CustomerVerified); 