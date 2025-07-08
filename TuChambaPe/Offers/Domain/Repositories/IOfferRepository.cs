using TuChambaPe.Offers.Domain.Model.Aggregates;
using TuChambaPe.Shared.Domain.Repositories;

namespace TuChambaPe.Offers.Domain.Repositories;

public interface IOfferRepository : IBaseRepository<Offer>
{
    Task<Offer?> FindByUidAsync(Guid uid);
    Task<IEnumerable<Offer>> FindByUserUidAsync(Guid userUid);
    Task SetInProcessAsync(Guid offerUid, Guid selectedProposalUid);
    Task IncrementProposalsCountAsync(Guid offerUid);
}