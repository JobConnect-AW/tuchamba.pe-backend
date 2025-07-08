using TuChambaPe.Offers.Domain.Model.ValueObjects;

namespace TuChambaPe.Offers.Interfaces.REST.Resources;

public record CreateOfferResource(
    Guid Uid,
    string Title,
    string Description,
    int CategoryId,
    float Amount,
    string Duration,
    string PaymentMethod,
    string Status,
    Guid? SelectedProposalUid = null,
    DateTimeOffset? StartAt = null,
    int ProposalsCount = 0
); 