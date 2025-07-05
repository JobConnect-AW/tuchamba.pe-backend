using TuChambaPe.Users.Domain.Model.Aggregates;
using TuChambaPe.Users.Domain.Repositories;
using TuChambaPe.Shared.Infrastructure.Persistence.EFC.Configuration;
using TuChambaPe.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace TuChambaPe.Users.Infrastructure.Persistence.EFC.Repositories;

/**
 * <summary>
 *     The user repository
 * </summary>
 * <remarks>
 *     This repository is used to manage users
 * </remarks>
 */
public class UserRepository(AppDbContext context) : BaseRepository<User>(context), IUserRepository
{

    public async Task<User?> FindByAccountIdAsync(Guid accountId)
    {
        return await Context.Set<User>().FirstOrDefaultAsync(user => user.AccountId.Equals(accountId));
    }

    public bool ExistsByAccountId(Guid accountId)
    {
        return Context.Set<User>().Any(user => user.AccountId.Equals(accountId));
    }
}