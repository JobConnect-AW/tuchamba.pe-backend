namespace TuChambaPe.Payments.Interfaces.REST.Resources;

/// <summary>
///     Verify payment resource for REST API
/// </summary>
/// <param name="VerifiedByWorker">Whether verified by worker</param>
/// <param name="VerifiedByCustomer">Whether verified by customer</param>
public record VerifyPaymentResource(bool VerifiedByWorker, bool VerifiedByCustomer); 