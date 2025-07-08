using TuChambaPe.Payments.Domain.Model.Commands;
using TuChambaPe.Payments.Domain.Model.ValueObjects;
using TuChambaPe.Payments.Interfaces.REST.Resources;

namespace TuChambaPe.Payments.Interfaces.REST.Transform;

/// <summary>
///     Assembler class to convert CreatePaymentResource to CreatePaymentCommand
/// </summary>
public static class CreatePaymentCommandFromResourceAssembler
{
    /// <summary>
    ///     Convert CreatePaymentResource to CreatePaymentCommand
    /// </summary>
    /// <param name="resource">The CreatePaymentResource to convert</param>
    /// <returns>The CreatePaymentCommand command</returns>
    public static CreatePaymentCommand ToCommandFromResource(CreatePaymentResource resource)
    {
        return new CreatePaymentCommand(
            resource.Uid,
            new OfferUid(resource.OfferUid),
            resource.Amount,
            Currency.Validate(resource.Currency));
    }
} 