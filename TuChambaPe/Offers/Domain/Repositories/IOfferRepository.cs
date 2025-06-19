using TuChambaPe.Offer.Domain.Model.Aggregates;
using TuChambaPe.Offer.Domain.Model.ValueObjects;
using TuChambaPe.Shared.Domain.Repositories;
 
namespace TuChambaPe.Offer.Domain.Repositories;

public interface IOfferRepository : IBaseRepository<Offer>
{
    Task<IEnumerable<Offer?>> Find();
    Task<Offer?> FindById(id string);
    Task<Offer?> Save(Offer offer);
    Task<Offer?> Update(Offer offer);
    Task<void> Delete(id string);
}