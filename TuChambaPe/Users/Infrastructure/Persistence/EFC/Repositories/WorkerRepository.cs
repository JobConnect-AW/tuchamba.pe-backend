using TuChambaPe.Users.Domain.Model.Aggregates;
using TuChambaPe.Users.Domain.Repositories;
using TuChambaPe.Shared.Infrastructure.Persistence.EFC.Configuration;
using TuChambaPe.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace TuChambaPe.Users.Infrastructure.Persistence.EFC.Repositories;

/**
 * <summary>
 *     The worker repository
 * </summary>
 * <remarks>
 *     This repository is used to manage workers
 * </remarks>
 */
public class WorkerRepository(AppDbContext context) : BaseRepository<Worker>(context), IWorkerRepository
{

    public async Task<IEnumerable<Worker>> GetByLocationAsync(string location)
    {
        return await Context.Set<Worker>()
            .Where(worker => worker.Location.Contains(location))
            .ToListAsync();
    }

    public async Task<IEnumerable<Worker>> GetBySkillsAsync(List<string> skills)
    {
        return await Context.Set<Worker>()
            .Where(worker => skills.Any(skill => worker.Skills.Contains(skill)))
            .ToListAsync();
    }

    public async Task<IEnumerable<Worker>> GetVerifiedWorkersAsync()
    {
        return await Context.Set<Worker>()
            .Where(worker => worker.IsVerified)
            .ToListAsync();
    }

    public async Task<IEnumerable<Worker>> GetByRatingRangeAsync(double minRating, double maxRating)
    {
        return await Context.Set<Worker>()
            .Where(worker => worker.Rating >= minRating && worker.Rating <= maxRating)
            .ToListAsync();
    }

    public async Task<Worker?> FindByUserUidAsync(Guid userUid)
    {
        return await Context.Set<Worker>().FirstOrDefaultAsync(w => w.UserUid == userUid);
    }
}