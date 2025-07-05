using TuChambaPe.Users.Domain.Model.Aggregates;
using TuChambaPe.Shared.Domain.Repositories;

namespace TuChambaPe.Users.Domain.Repositories;

/**
 * <summary>
 *     The worker repository
 * </summary>
 * <remarks>
 *     This repository is used to manage workers
 * </remarks>
 */
public interface IWorkerRepository : IBaseRepository<Worker>
{
    Task<IEnumerable<Worker>> GetByLocationAsync(string location);

    Task<IEnumerable<Worker>> GetBySkillsAsync(List<string> skills);

    Task<IEnumerable<Worker>> GetVerifiedWorkersAsync();

    Task<IEnumerable<Worker>> GetByRatingRangeAsync(double minRating, double maxRating);
}