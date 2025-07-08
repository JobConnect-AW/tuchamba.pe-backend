using TuChambaPe.Offers.Domain.Model.Commands;
using TuChambaPe.Offers.Interfaces.REST.Resources;

namespace TuChambaPe.Offers.Interfaces.REST.Transform;

public static class CreateOfferCommandFromResourceAssembler
{
    public static CreateOfferCommand ToCommandFromResource(CreateOfferResource resource)
    {
        return new CreateOfferCommand(
            Guid.NewGuid(),
            resource.Title,
            resource.Description,
            resource.Category,
            resource.Amount,
            resource.Duration,
            resource.PaymentMethod,
            resource.Status,
            resource.MinimumExperience,
            resource.WorkSchedule,
            resource.UserUid);
    }
}