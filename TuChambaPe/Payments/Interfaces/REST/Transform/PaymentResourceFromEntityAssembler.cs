using TuChambaPe.Payments.Domain.Model.Aggregates;
using TuChambaPe.Payments.Interfaces.REST.Resources;

namespace TuChambaPe.Payments.Interfaces.REST.Transform;

/// <summary>
///     Assembler class to convert Payment entity to PaymentResource
/// </summary>
public static class PaymentResourceFromEntityAssembler
{
    /// <summary>
    ///     Convert Payment entity to PaymentResource
    /// </summary>
    /// <param name="entity">The Payment entity to convert</param>
    /// <returns>The PaymentResource resource</returns>
    public static PaymentResource ToResourceFromEntity(Payment entity)
    {
        return new PaymentResource(
            entity.Uid,
            entity.OfferUid.Value,
            entity.Amount,
            entity.Currency,
            entity.Status,
            entity.CreatedDate,
            entity.UpdatedDate,
            entity.WorkerVerified,
            entity.CustomerVerified);
    }
} 