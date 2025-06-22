using TuChambaPe.Offers.Domain.Model.Aggregates;
using TuChambaPe.Offers.Domain.Model.Queries;
using TuChambaPe.Offers.Domain.Repositories;
using TuChambaPe.Offers.Domain.Services;

namespace TuChambaPe.Offers.Application.Internal.QueryServices;

/**
 * <summary>
 *     The offer query service implementation class
 * </summary>
 * <remarks>
 *     This class is used to handle offer queries
 * </remarks>
 */
public class OfferQueryService(IOfferRepository offerRepository) : IOfferQueryService
{
    /**
     * <summary>
     *     Handle get offer by id query
     * </summary>
     * <param name="query">The query object containing the offer id to search</param>
     * <returns>The offer</returns>
     */
    public async Task<Offer?> Handle(GetOfferById query)
    {
        return await offerRepository.FindByUidAsync(query.Id);
    }

    /**
     * <summary>
     *     Handle get all offers query
     * </summary>
     * <param name="query">The query object for getting all offers</param>
     * <returns>The offers</returns>
     */
    public async Task<IEnumerable<Offer>> Handle(GetAllOffersQuery query)
    {
        return await offerRepository.ListAsync();
    }
} 