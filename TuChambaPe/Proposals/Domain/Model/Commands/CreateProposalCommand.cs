using TuChambaPe.Proposals.Domain.Model.ValueObjects;

namespace TuChambaPe.Proposals.Domain.Model.Commands;

public record CreateProposalCommand(
    Guid Uid,
    Guid OfferUid,
    Guid WorkerUid,
    string Message,
    decimal Price,
    DateTime CreatedAt,
    string? Status
); 