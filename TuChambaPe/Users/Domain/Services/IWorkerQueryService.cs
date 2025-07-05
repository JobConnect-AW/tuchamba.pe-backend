using TuChambaPe.Users.Domain.Model.Aggregates;
using TuChambaPe.Users.Domain.Model.Queries;

namespace TuChambaPe.Users.Domain.Services;

/**
 * <summary>
 *     The worker query service
 * </summary>
 * <remarks>
 *     This interface is used to handle worker queries
 * </remarks>
 */
public interface IWorkerQueryService
{
    Task<Worker?> Handle(GetWorkerByUidQuery query);

    Task<IEnumerable<Worker>> GetAllAsync();

    Task<IEnumerable<Worker>> GetByLocationAsync(string location);

    Task<IEnumerable<Worker>> GetBySkillsAsync(List<string> skills);

    Task<IEnumerable<Worker>> GetVerifiedWorkersAsync();

    Task<IEnumerable<Worker>> GetByRatingRangeAsync(double minRating, double maxRating);
}