using TuChambaPe.Offers.Domain.Model.Aggregates;
using TuChambaPe.Shared.Domain.Repositories;

namespace TuChambaPe.Offers.Domain.Repositories;

public interface IOfferRepository : IBaseRepository<Offer>
{
    Task IncrementProposalsCountAsync(Guid offerUid);
    Task SetInProcessAsync(Guid offerUid, Guid selectedProposalUid);
}