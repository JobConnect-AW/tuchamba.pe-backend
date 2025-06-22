using TuChambaPe.Proposals.Domain.Model.ValueObjects;

namespace TuChambaPe.Proposals.Interfaces.REST.Resources;

public record UpdateProposalResource(string Title, string Description, decimal Price, string EstimatedTime, string Status); 