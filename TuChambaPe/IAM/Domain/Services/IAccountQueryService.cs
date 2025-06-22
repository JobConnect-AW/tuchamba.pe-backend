using TuChambaPe.IAM.Domain.Model.Aggregates;
using TuChambaPe.IAM.Domain.Model.Queries;

namespace TuChambaPe.IAM.Domain.Services
{

    /**
     * <summary>
     *     The account query service interface
     * </summary>
     * <remarks>
     *     This service contract specifies handling behavior used to query accounts
     * </remarks>
     */
    public interface IAccountQueryService
    {
        /**
         * <summary>
         *     Handle get account by id query
         * </summary>
         * <param name="query">The get account by id query</param>
         * <returns>The account if found, null otherwise</returns>
         */
        Task<Account?> Handle(GetAccountByUidQuery query);

        /**
         * <summary>
         *     Handle get all accounts query
         * </summary>
         * <param name="query">The get all accounts query</param>
         * <returns>The list of accounts</returns>
         */
        Task<IEnumerable<Account>> Handle(GetAllAccountsQuery query);

        /**
         * <summary>
         *     Handle get account by email query
         * </summary>
         * <param name="query">The get account by email query</param>
         * <returns>The account if found, null otherwise</returns>
         */
        Task<Account?> Handle(GetAccountByEmailQuery query);
    }
} 