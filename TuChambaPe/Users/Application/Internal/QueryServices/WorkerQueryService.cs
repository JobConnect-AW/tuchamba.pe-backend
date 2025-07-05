using TuChambaPe.Users.Domain.Model.Aggregates;
using TuChambaPe.Users.Domain.Model.Queries;
using TuChambaPe.Users.Domain.Repositories;
using TuChambaPe.Users.Domain.Services;

namespace TuChambaPe.Users.Application.Internal.QueryServices;

/**
 * <summary>
 *     The worker query service
 * </summary>
 * <remarks>
 *     This service is used to handle worker queries
 * </remarks>
 */
public class WorkerQueryService(IWorkerRepository workerRepository) : IWorkerQueryService
{
    /**
     * <summary>
     *     Handle get worker by uid query
     * </summary>
     * <param name="query">The get worker by uid query</param>
     * <returns>The worker if found, null otherwise</returns>
     */
    public async Task<Worker?> Handle(GetWorkerByUidQuery query)
    {
        return await workerRepository.FindByUidAsync(query.Uid);
    }

    /**
     * <summary>
     *     Get all workers
     * </summary>
     * <returns>List of all workers</returns>
     */
    public async Task<IEnumerable<Worker>> GetAllAsync()
    {
        return await workerRepository.ListAsync();
    }

    /**
     * <summary>
     *     Get workers by location
     * </summary>
     * <param name="location">The location to filter by</param>
     * <returns>List of workers in the specified location</returns>
     */
    public async Task<IEnumerable<Worker>> GetByLocationAsync(string location)
    {
        return await workerRepository.GetByLocationAsync(location);
    }

    /**
     * <summary>
     *     Get workers by skills
     * </summary>
     * <param name="skills">The skills to filter by</param>
     * <returns>List of workers with the specified skills</returns>
     */
    public async Task<IEnumerable<Worker>> GetBySkillsAsync(List<string> skills)
    {
        return await workerRepository.GetBySkillsAsync(skills);
    }

    /**
     * <summary>
     *     Get verified workers
     * </summary>
     * <returns>List of verified workers</returns>
     */
    public async Task<IEnumerable<Worker>> GetVerifiedWorkersAsync()
    {
        return await workerRepository.GetVerifiedWorkersAsync();
    }

    /**
     * <summary>
     *     Get workers by rating range
     * </summary>
     * <param name="minRating">Minimum rating</param>
     * <param name="maxRating">Maximum rating</param>
     * <returns>List of workers within the rating range</returns>
     */
    public async Task<IEnumerable<Worker>> GetByRatingRangeAsync(double minRating, double maxRating)
    {
        return await workerRepository.GetByRatingRangeAsync(minRating, maxRating);
    }
}