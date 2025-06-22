using TuChambaPe.IAM.Domain.Model.Aggregates;
using TuChambaPe.IAM.Domain.Repositories;
using TuChambaPe.Shared.Infrastructure.Persistence.EFC.Configuration;
using TuChambaPe.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace TuChambaPe.IAM.Infrastructure.Persistence.EFC.Repositories;

/**
 * <summary>
 *     The account repository
 * </summary>
 * <remarks>
 *     This repository is used to manage accounts
 * </remarks>
 */
public class AccountRepository(AppDbContext context) : BaseRepository<Account>(context), IAccountRepository
{
    /**
     * <summary>
     *     Find an account by email
     * </summary>
     * <param name="email">The email to search</param>
     * <returns>The account</returns>
     */
    public async Task<Account?> FindByEmailAsync(string email)
    {
        return await Context.Set<Account>().FirstOrDefaultAsync(account => account.Email.Equals(email));
    }

    /**
     * <summary>
     *     Check if an account exists by email
     * </summary>
     * <param name="email">The email to search</param>
     * <returns>True if the account exists, false otherwise</returns>
     */
    public bool ExistsByEmail(string email)
    {
        return Context.Set<Account>().Any(account => account.Email.Equals(email));
    }
} 