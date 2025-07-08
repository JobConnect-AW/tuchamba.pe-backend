using TuChambaPe.Proposals.Domain.Model.ValueObjects;

namespace TuChambaPe.Proposals.Interfaces.REST.Resources;

public record UpdateProposalResource(
    Guid OfferUid,
    Guid WorkerUid,
    string Message,
    decimal Price,
    string? UpdatedBy,
    string Status
); 