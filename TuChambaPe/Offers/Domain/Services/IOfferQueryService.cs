using TuChambaPe.Offers.Domain.Model.Aggregates;
using TuChambaPe.Offers.Domain.Model.Queries;

namespace TuChambaPe.Offers.Domain.Services;

public interface IOfferQueryService
{
    Task<Offer?> Handle(GetOfferById query);
    Task<IEnumerable<Offer>> Handle(GetAllOffersQuery query);
} 