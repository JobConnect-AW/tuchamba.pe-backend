using TuChambaPe.Proposals.Domain.Model.Commands;
using TuChambaPe.Proposals.Interfaces.REST.Resources;

namespace TuChambaPe.Proposals.Interfaces.REST.Transform;

public static class CreateProposalCommandFromResourceAssembler
{
    public static CreateProposalCommand ToCommandFromResource(CreateProposalResource resource)
    {
        return new CreateProposalCommand(
            Guid.NewGuid(),
            resource.WorkerUid,
            resource.CustomerUid,
            resource.Title,
            resource.Description,
            resource.Price,
            resource.EstimatedTime,
            resource.Status,
            DateTime.UtcNow);
    }
} 