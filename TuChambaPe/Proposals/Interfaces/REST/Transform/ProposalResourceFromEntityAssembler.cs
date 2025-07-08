using TuChambaPe.Proposals.Domain.Model.Aggregates;
using TuChambaPe.Proposals.Interfaces.REST.Resources;

namespace TuChambaPe.Proposals.Interfaces.REST.Transform;

public static class ProposalResourceFromEntityAssembler
{
    public static ProposalResource ToResourceFromEntity(Proposal proposal)
    {
        return new ProposalResource(
            proposal.Uid,
            proposal.OfferUid,
            proposal.WorkerUid,
            proposal.Message,
            proposal.Price,
            proposal.CreatedAt,
            proposal.UpdatedAt,
            proposal.CreatedBy,
            proposal.UpdatedBy,
            proposal.Status
        );
    }
} 