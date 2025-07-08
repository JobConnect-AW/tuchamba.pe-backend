using TuChambaPe.Offers.Domain.Model.ValueObjects;

namespace TuChambaPe.Offers.Interfaces.REST.Resources;

public record OfferResource(Guid Uid, string Title, string Description, int CategoryId, float Amount, string Duration, string PaymentMethod, string Status,  int ProposalsCount, Guid? SelectedProposalUid, DateTimeOffset? StartAt); 