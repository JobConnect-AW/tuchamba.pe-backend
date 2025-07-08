using TuChambaPe.Offers.Domain.Model.Aggregates;
using TuChambaPe.Offers.Domain.Repositories;
using TuChambaPe.Shared.Infrastructure.Persistence.EFC.Configuration;
using TuChambaPe.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;


namespace TuChambaPe.Offers.Infrastructure.Persistence.EFC.Repositories;

public class OfferRepository(AppDbContext context)
    : BaseRepository<Offer>(context), IOfferRepository
{
    public async Task<Offer?> FindByUidAsync(Guid uid)
    {
        return await Context.Set<Offer>().FirstOrDefaultAsync(o => o.Uid == uid);
    }

    public async Task<IEnumerable<Offer>> FindByUserUidAsync(Guid userUid)
    {
        return await Context.Set<Offer>().Where(o => o.UserUid == userUid).ToListAsync();
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