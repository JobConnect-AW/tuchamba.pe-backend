using TuChambaPe.Proposals.Domain.Model.Aggregates;
using TuChambaPe.Shared.Domain.Repositories;

namespace TuChambaPe.Proposals.Domain.Repositories;

public interface IProposalRepository : IBaseRepository<Proposal>
{
     /// <summary>
     ///     Update an existing proposal
     /// </summary>
     /// <param name="proposal">The proposal to update</param>
     Task UpdateAsync(Proposal proposal);
} 