using TuChambaPe.Offers.Domain.Model.Aggregates;
using TuChambaPe.Offers.Interfaces.REST.Resources;

namespace TuChambaPe.Offers.Interfaces.REST.Transform;

public static class OfferResourceFromEntityAssembler
{
    public static OfferResource ToResourceFromEntity(Offer offer)
    {
        return new OfferResource(
            offer.Uid,
            offer.Title,
            offer.Description,
            offer.Category,
            offer.Amount,
            offer.Duration,
            offer.PaymentMethod,
            offer.Status,
            offer.MinimumExperience,
            offer.WorkSchedule,
            offer.UserUid,
            offer.ProposalsCount,
            offer.SelectedProposalUid,
            offer.StartAt
        );
    }
}