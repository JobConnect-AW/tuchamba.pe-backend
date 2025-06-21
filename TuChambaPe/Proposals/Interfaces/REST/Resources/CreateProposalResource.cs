using TuChambaPe.Proposals.Domain.Model.ValueObjects;

namespace TuChambaPe.Proposals.Interfaces.REST.Resources;

public record CreateProposalResource(Guid WorkerUid, Guid CustomerUid, string Title, string Description, decimal Price, string EstimatedTime, string Status); 