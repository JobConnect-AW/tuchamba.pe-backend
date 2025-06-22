using TuChambaPe.Proposals.Domain.Model.ValueObjects;

namespace TuChambaPe.Proposals.Domain.Model.Commands;

public record CreateProposalCommand(
    Guid Uid,
    Guid WorkerUid,
    Guid CustomerUid,
    string Title,
    string Description,
    decimal Price,
    string EstimatedTime,
    string Status,
    DateTime SubmittedAt
); 