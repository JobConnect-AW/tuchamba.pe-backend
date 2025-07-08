using TuChambaPe.Proposals.Domain.Model.ValueObjects;

namespace TuChambaPe.Proposals.Domain.Model.Commands;

public record UpdateProposalCommand(
    Guid Uid,
    Guid OfferUid,
    Guid WorkerUid,
    string Message,
    decimal Price,
    DateTime? UpdatedAt,
    string? UpdatedBy,
    string Status
); 