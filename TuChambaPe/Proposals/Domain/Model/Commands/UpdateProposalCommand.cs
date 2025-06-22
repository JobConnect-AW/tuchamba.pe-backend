using TuChambaPe.Proposals.Domain.Model.ValueObjects;

namespace TuChambaPe.Proposals.Domain.Model.Commands;

public record UpdateProposalCommand(
    Guid Uid,
    string Title,
    string Description,
    decimal Price,
    string EstimatedTime,
    string Status
); 