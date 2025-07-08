using TuChambaPe.Payments.Domain.Model.ValueObjects;

namespace TuChambaPe.Payments.Domain.Model.Commands;

/// <summary>
///     Command to update payment status
/// </summary>
/// <param name="PaymentUid">The payment UID to update</param>
/// <param name="Status">The new payment status</param>
public record UpdatePaymentStatusCommand(Guid PaymentUid, string Status); 