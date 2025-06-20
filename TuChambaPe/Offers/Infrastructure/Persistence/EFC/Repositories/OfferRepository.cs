using TuChambaPe.Offers.Domain.Model.Aggregates;
using TuChambaPe.Offers.Domain.Repositories;
using TuChambaPe.Shared.Infrastructure.Persistence.EFC.Configuration;
using TuChambaPe.Shared.Infrastructure.Persistence.EFC.Repositories;


namespace TuChambaPe.Offers.Infrastructure.Persistence.EFC.Repositories;

public class OfferRepository(AppDbContext context)
    : BaseRepository<Offer>(context), IOfferRepository
{
    
}