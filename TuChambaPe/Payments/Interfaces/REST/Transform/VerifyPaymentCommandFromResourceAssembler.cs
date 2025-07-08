using TuChambaPe.Payments.Domain.Model.Commands;
using TuChambaPe.Payments.Interfaces.REST.Resources;

namespace TuChambaPe.Payments.Interfaces.REST.Transform;

/// <summary>
///     Assembler class to convert VerifyPaymentResource to VerifyPaymentCommand
/// </summary>
public static class VerifyPaymentCommandFromResourceAssembler
{
    /// <summary>
    ///     Convert VerifyPaymentResource to VerifyPaymentCommand
    /// </summary>
    /// <param name="resource">The VerifyPaymentResource to convert</param>
    /// <param name="paymentUid">The payment Uid</param>
    /// <returns>The VerifyPaymentCommand command</returns>
    public static VerifyPaymentCommand ToCommandFromResource(VerifyPaymentResource resource, Guid paymentUid)
    {
        return new VerifyPaymentCommand(
            paymentUid,
            resource.VerifiedByWorker,
            resource.VerifiedByCustomer);
    }
} 