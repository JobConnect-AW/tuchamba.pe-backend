using TuChambaPe.Users.Domain.Model.Aggregates;
using TuChambaPe.Shared.Domain.Repositories;

namespace TuChambaPe.Users.Domain.Repositories;

/**
 * <summary>
 *     The user repository
 * </summary>
 * <remarks>
 *     This repository is used to manage users
 * </remarks>
 */
public interface IUserRepository : IBaseRepository<User>
{

    Task<User?> FindByAccountIdAsync(Guid accountId);

    bool ExistsByAccountId(Guid accountId);

    Task<User?> FindByUidAsync(Guid uid);
}