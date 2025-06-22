using TuChambaPe.IAM.Domain.Model.Aggregates;
using TuChambaPe.Shared.Domain.Repositories;

namespace TuChambaPe.IAM.Domain.Repositories;

/**
 * <summary>
 *     The account repository
 * </summary>
 * <remarks>
 *     This repository is used to manage accounts
 * </remarks>
 */
public interface IAccountRepository : IBaseRepository<Account>
{
    /**
     * <summary>
     *     Find an account by email
     * </summary>
     * <param name="email">The email to search</param>
     * <returns>The account</returns>
     */
    Task<Account?> FindByEmailAsync(string email);

    bool ExistsByEmail(string email);
} 