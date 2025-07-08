using TuChambaPe.Offers.Domain.Model.Aggregates;
using TuChambaPe.Offers.Domain.Repositories;
using TuChambaPe.Shared.Infrastructure.Persistence.EFC.Configuration;
using TuChambaPe.Shared.Infrastructure.Persistence.EFC.Repositories;


namespace TuChambaPe.Offers.Infrastructure.Persistence.EFC.Repositories;

public class OfferRepository(AppDbContext context)
    : BaseRepository<Offer>(context), IOfferRepository
{
    
    
    public async Task IncrementProposalsCountAsync(Guid offerUid)
    {
        var offer = await Context.Set<Offer>().FindAsync(offerUid);
        if (offer != null)
        {
            offer.IncrementProposalsCount();
            await context.SaveChangesAsync();
        }
    }

    public async Task SetInProcessAsync(Guid offerUid, Guid selectedProposalUid)
    {
        var offer = await Context.Set<Offer>().FindAsync(offerUid);
        if (offer != null)
        {
            offer.SetInProcess(selectedProposalUid);
            await context.SaveChangesAsync();
        }
    }
    
    
}