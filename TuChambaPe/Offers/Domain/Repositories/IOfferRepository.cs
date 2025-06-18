using TuChambaPe.Offer.Domain.Model.Aggregates;
using TuChambaPe.Offer.Domain.Model.ValueObjects;
using TuChambaPe.Shared.Domain.Repositories;
 
namespace TuChambaPe.Offer.Domain.Repositories;

public interface IOfferRepository : IBaseRepository<Offer>
{
    Task<IEnumerable<Offer?>> find();
    Task<Offer?> findById(id string);
    Task<Offer?> save(Offer offer);
    Task<Offer?> update(Offer offer);
    Task<void> delete(id string);
}