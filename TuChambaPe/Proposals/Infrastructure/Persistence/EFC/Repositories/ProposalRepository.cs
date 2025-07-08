using TuChambaPe.Proposals.Domain.Model.Aggregates;
using TuChambaPe.Proposals.Domain.Repositories;
using TuChambaPe.Shared.Infrastructure.Persistence.EFC.Configuration;
using TuChambaPe.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace TuChambaPe.Proposals.Infrastructure.Persistence.EFC.Repositories;

public class ProposalRepository(AppDbContext context)
    : BaseRepository<Proposal>(context), IProposalRepository
{
    public new async Task UpdateAsync(Proposal proposal)
    {
        Context.Set<Proposal>().Update(proposal);
        await Task.CompletedTask;
    }
} 