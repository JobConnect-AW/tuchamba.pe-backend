using TuChambaPe.IAM.Domain.Model.Aggregates;
using TuChambaPe.IAM.Domain.Model.Queries;
using TuChambaPe.IAM.Domain.Repositories;
using TuChambaPe.IAM.Domain.Services;

namespace TuChambaPe.IAM.Application.Internal.QueryServices;

/**
 * <summary>
 *     The user query service implementation class
 * </summary>
 * <remarks>
 *     This class is used to handle user queries
 * </remarks>
 */
public class UserQueryService(IUserRepository userRepository) : IUserQueryService
{
    /**
     * <summary>
     *     Handle get user by id query
     * </summary>
     * <param name="query">The query object containing the user id to search</param>
     * <returns>The user</returns>
     */
    public async Task<User?> Handle(GetUserByUidQuery query)
    {
        return await userRepository.FindByUidAsync(query.Uid);
    }

    /**
     * <summary>
     *     Handle get user by username query
     * </summary>
     * <param name="query">The query object for getting all users</param>
     * <returns>The user</returns>
     */
    public async Task<IEnumerable<User>> Handle(GetAllUsersQuery query)
    {
        return await userRepository.ListAsync();
    }

    /**
     * <summary>
     *     Handle get user by username query
     * </summary>
     * <param name="query">The query object containing the username to search</param>
     * <returns>The user</returns>
     */
    public async Task<User?> Handle(GetUserByEmailQuery query)
    {
        return await userRepository.FindByEmailAsync(query.Email);
    }
}