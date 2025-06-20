using LearningCenterPlatform.Shared.Infrastructure.Persistence.EFC.Repositories;
using TuChambaPe.Offers.Domain.Model.Aggregates;
using TuChambaPe.Offers.Domain.Model.ValueObjects;
using TuChambaPe.Offers.Domain.Repositories;
using TuChambaPe.Shared.Infrastructure.Persistence.EFC.Configuration;
using TuChambaPe.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace TuChambaPe.Offers.Infrastructure.Persistence.EFC.Repositories;

public class OfferRepository(AppDbContext context)
    : BaseRepository<Offer>(context), IOfferRepository
{
    public async Task<Offer?> FindById(string id)
    {
        return await Context.Set<Offer>().FirstOrDefault(p => p.Id == id);
    }
}