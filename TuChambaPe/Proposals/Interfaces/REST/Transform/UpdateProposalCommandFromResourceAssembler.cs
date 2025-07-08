using TuChambaPe.Proposals.Domain.Model.Commands;
using TuChambaPe.Proposals.Interfaces.REST.Resources;

namespace TuChambaPe.Proposals.Interfaces.REST.Transform;

public static class UpdateProposalCommandFromResourceAssembler
{
    public static UpdateProposalCommand ToCommandFromResource(Guid uid, UpdateProposalResource resource)
    {
        return new UpdateProposalCommand(
            uid,
            resource.OfferUid,
            resource.WorkerUid,
            resource.Message,
            resource.Price,
            DateTime.UtcNow,
            resource.UpdatedBy,
            resource.Status
        );
    }
} 