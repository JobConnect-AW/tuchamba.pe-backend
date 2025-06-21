using TuChambaPe.Proposals.Domain.Model.Aggregates;
using TuChambaPe.Proposals.Interfaces.REST.Resources;

namespace TuChambaPe.Proposals.Interfaces.REST.Transform;

public static class ProposalResourceFromEntityAssembler
{
    public static ProposalResource ToResourceFromEntity(Proposal proposal)
    {
        return new ProposalResource(
            proposal.Id,
            proposal.Uid,
            proposal.WorkerUid,
            proposal.CustomerUid,
            proposal.Title,
            proposal.Description,
            proposal.Price,
            proposal.EstimatedTime,
            proposal.Status,
            proposal.SubmittedAt);
    }
} 