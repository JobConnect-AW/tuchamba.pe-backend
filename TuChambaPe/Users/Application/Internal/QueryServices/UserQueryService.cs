using TuChambaPe.Users.Domain.Model.Aggregates;
using TuChambaPe.Users.Domain.Model.Queries;
using TuChambaPe.Users.Domain.Repositories;
using TuChambaPe.Users.Domain.Services;

namespace TuChambaPe.Users.Application.Internal.QueryServices;

/**
 * <summary>
 *     The user query service
 * </summary>
 * <remarks>
 *     This service is used to handle user queries
 * </remarks>
 */
public class UserQueryService(IUserRepository userRepository) : IUserQueryService
{
    /**
     * <summary>
     *     Handle get user by uid query
     * </summary>
     * <param name="query">The get user by uid query</param>
     * <returns>The user if found, null otherwise</returns>
     */
    public async Task<User?> Handle(GetUserByUidQuery query)
    {
        return await userRepository.FindByUidAsync(query.Uid);
    }

    /**
     * <summary>
     *     Handle get user by account id query
     * </summary>
     * <param name="query">The get user by account id query</param>
     * <returns>The user if found, null otherwise</returns>
     */
    public async Task<User?> Handle(GetUserByAccountIdQuery query)
    {
        return await userRepository.FindByAccountIdAsync(query.AccountId);
    }

    /**
     * <summary>
     *     Get all users
     * </summary>
     * <returns>List of all users</returns>
     */
    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await userRepository.ListAsync();
    }
}