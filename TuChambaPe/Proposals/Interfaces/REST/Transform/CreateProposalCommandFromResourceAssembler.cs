using TuChambaPe.Proposals.Domain.Model.Commands;
using TuChambaPe.Proposals.Interfaces.REST.Resources;

namespace TuChambaPe.Proposals.Interfaces.REST.Transform;

public static class CreateProposalCommandFromResourceAssembler
{
    public static CreateProposalCommand ToCommandFromResource(CreateProposalResource resource)
    {
        return new CreateProposalCommand(
            resource.Uid,
            resource.OfferUid,
            resource.WorkerUid,
            resource.Message,
            resource.Price,
            DateTime.UtcNow,
            resource.Status
        );
    }
} 