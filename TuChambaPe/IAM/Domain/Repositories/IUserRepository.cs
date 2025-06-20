using TuChambaPe.IAM.Domain.Model.Aggregates;
using TuChambaPe.Shared.Domain.Repositories;

namespace TuChambaPe.IAM.Domain.Repositories;

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
    /**
     * <summary>
     *     Find a user by email
     * </summary>
     * <param name="email">The email to search</param>
     * <returns>The user</returns>
     */
    Task<User?> FindByEmailAsync(string email);

    bool ExistsByEmail(string email);
}