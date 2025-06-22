using TuChambaPe.Proposals.Domain.Model.Aggregates;
using TuChambaPe.Proposals.Domain.Model.Queries;

namespace TuChambaPe.Proposals.Domain.Services;

public interface IProposalQueryService
{
    Task<Proposal?> Handle(GetProposalById query);
    Task<IEnumerable<Proposal>> Handle(GetAllProposalsQuery query);
    Task<IEnumerable<Proposal>> Handle(GetProposalsByWorkerId query);
    Task<IEnumerable<Proposal>> Handle(GetProposalsByCustomerId query);
} 