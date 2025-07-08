using TuChambaPe.Proposals.Domain.Model.ValueObjects;

namespace TuChambaPe.Proposals.Interfaces.REST.Resources;

public record CreateProposalResource(
    Guid Uid,
    Guid OfferUid,
    Guid WorkerUid,
    string Message,
    decimal Price,
    string? Status = null
); 