using TuChambaPe.IAM.Domain.Model.Aggregates;
using TuChambaPe.IAM.Domain.Model.Queries;
using TuChambaPe.IAM.Domain.Repositories;
using TuChambaPe.IAM.Domain.Services;

namespace TuChambaPe.IAM.Application.Internal.QueryServices;

/**
 * <summary>
 *     The account query service implementation class
 * </summary>
 * <remarks>
 *     This class is used to handle account queries
 * </remarks>
 */
public class AccountQueryService(IAccountRepository accountRepository) : IAccountQueryService
{
    /**
     * <summary>
     *     Handle get account by id query
     * </summary>
     * <param name="query">The query object containing the account id to search</param>
     * <returns>The account</returns>
     */
    public async Task<Account?> Handle(GetAccountByUidQuery query)
    {
        return await accountRepository.FindByUidAsync(query.Uid);
    }

    /**
     * <summary>
     *     Handle get account by username query
     * </summary>
     * <param name="query">The query object for getting all accounts</param>
     * <returns>The account</returns>
     */
    public async Task<IEnumerable<Account>> Handle(GetAllAccountsQuery query)
    {
        return await accountRepository.ListAsync();
    }

    /**
     * <summary>
     *     Handle get account by username query
     * </summary>
     * <param name="query">The query object containing the username to search</param>
     * <returns>The account</returns>
     */
    public async Task<Account?> Handle(GetAccountByEmailQuery query)
    {
        return await accountRepository.FindByEmailAsync(query.Email);
    }
} 