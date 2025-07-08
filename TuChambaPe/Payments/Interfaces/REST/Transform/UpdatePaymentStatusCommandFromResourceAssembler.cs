using TuChambaPe.Payments.Domain.Model.Commands;
using TuChambaPe.Payments.Domain.Model.ValueObjects;
using TuChambaPe.Payments.Interfaces.REST.Resources;

namespace TuChambaPe.Payments.Interfaces.REST.Transform;

/// <summary>
///     Assembler class to convert UpdatePaymentStatusResource to UpdatePaymentStatusCommand
/// </summary>
public static class UpdatePaymentStatusCommandFromResourceAssembler
{
    /// <summary>
    ///     Convert UpdatePaymentStatusResource to UpdatePaymentStatusCommand
    /// </summary>
    /// <param name="resource">The UpdatePaymentStatusResource to convert</param>
    /// <param name="paymentUid">The payment ID</param>
    /// <returns>The UpdatePaymentStatusCommand command</returns>
    public static UpdatePaymentStatusCommand ToCommandFromResource(UpdatePaymentStatusResource resource, Guid paymentUid)
    {
        return new UpdatePaymentStatusCommand(
            paymentUid,
            PaymentStatus.Validate(resource.Status));
    }
} 