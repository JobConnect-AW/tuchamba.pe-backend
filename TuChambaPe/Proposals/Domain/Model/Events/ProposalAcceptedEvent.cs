using TuChambaPe.Shared.Domain.Model.Events;

namespace TuChambaPe.Proposals.Domain.Model.Events;

public record ProposalAcceptedEvent(Guid ProposalUid, Guid OfferUid) : IEvent; 