namespace TuChambaPe.Payments.Domain.Model.Commands;

/// <summary>
///     Command to verify payment
/// </summary>
/// <param name="PaymentUid">The payment UID to verify</param>
/// <param name="VerifiedByWorker">Whether verified by worker</param>
/// <param name="VerifiedByCustomer">Whether verified by customer</param>
public record VerifyPaymentCommand(Guid PaymentUid, bool VerifiedByWorker, bool VerifiedByCustomer); 