using TuChambaPe.Proposals.Domain.Model.Aggregates;
using TuChambaPe.Proposals.Domain.Model.Queries;
using TuChambaPe.Proposals.Domain.Repositories;
using TuChambaPe.Proposals.Domain.Services;

namespace TuChambaPe.Proposals.Application.Internal.QueryServices;

/**
 * <summary>
 *     The proposal query service implementation class
 * </summary>
 * <remarks>
 *     This class is used to handle proposal queries
 * </remarks>
 */
public class ProposalQueryService(IProposalRepository proposalRepository) : IProposalQueryService
{
    /**
     * <summary>
     *     Handle get proposal by id query
     * </summary>
     * <param name="query">The query object containing the proposal id to search</param>
     * <returns>The proposal</returns>
     */
    public async Task<Proposal?> Handle(GetProposalById query)
    {
        return await proposalRepository.FindByUidAsync(query.Uid);
    }

    /**
     * <summary>
     *     Handle get all proposals query
     * </summary>
     * <param name="query">The query object for getting all proposals</param>
     * <returns>The proposals</returns>
     */
    public async Task<IEnumerable<Proposal>> Handle(GetAllProposalsQuery query)
    {
        return await proposalRepository.ListAsync();
    }

    /**
     * <summary>
     *     Handle get proposals by worker id query
     * </summary>
     * <param name="query">The query object containing the worker id to search</param>
     * <returns>The proposals</returns>
     */
    public async Task<IEnumerable<Proposal>> Handle(GetProposalsByWorkerId query)
    {
        var allProposals = await proposalRepository.ListAsync();
        return allProposals.Where(p => p.WorkerUid.Value == query.WorkerUid);
    }

    /**
     * <summary>
     *     Handle get proposals by offer id query
     * </summary>
     * <param name="query">The query object containing the offer id to search</param>
     * <returns>The proposals</returns>
     */
    public async Task<IEnumerable<Proposal>> Handle(GetProposalsByOfferId query)
    {
        var allProposals = await proposalRepository.ListAsync();
        return allProposals.Where(p => p.OfferUid.Value == query.OfferUid);
    }
} 