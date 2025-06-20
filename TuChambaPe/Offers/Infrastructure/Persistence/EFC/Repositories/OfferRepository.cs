using LearningCenterPlatform.Shared.Infrastructure.Persistence.EFC.Configuration;
using LearningCenterPlatform.Shared.Infrastructure.Persistence.EFC.Repositories;
using TuChambaPe.Offers.Domain.Model.Aggregates;
using TuChambaPe.Offers.Domain.Repositories;


namespace TuChambaPe.Offers.Infrastructure.Persistence.EFC.Repositories;

public class OfferRepository(AppDbContext context)
    : BaseRepository<Offer>(context), IOfferRepository
{
    
}