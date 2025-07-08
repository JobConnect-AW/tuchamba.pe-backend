using TuChambaPe.Offers.Domain.Model.Commands;
using TuChambaPe.Offers.Interfaces.REST.Resources;

namespace TuChambaPe.Offers.Interfaces.REST.Transform;

public static class UpdateOfferCommandFromResourceAssembler
{
    public static UpdateOfferCommand ToCommandFromResource(Guid uid, UpdateOfferResource resource)
    {
        return new UpdateOfferCommand(
            uid,
            resource.Title,
            resource.Description,
            resource.Category,
            resource.Amount,
            resource.Duration,
            resource.PaymentMethod,
            resource.Status);
    }
}