using TuChambaPe.Shared.Domain.Model.Events;

namespace TuChambaPe.Proposals.Domain.Model.Events;

public record ProposalCreatedEvent(Guid ProposalUid, Guid OfferUid) : IEvent; 