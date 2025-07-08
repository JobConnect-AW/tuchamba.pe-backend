using TuChambaPe.Proposals.Domain.Model.ValueObjects;

namespace TuChambaPe.Proposals.Interfaces.REST.Resources;

public record ProposalResource(
    Guid Uid,
    Guid OfferUid,
    Guid WorkerUid,
    string Message,
    decimal Price,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    string? CreatedBy,
    string? UpdatedBy,
    string Status
); 