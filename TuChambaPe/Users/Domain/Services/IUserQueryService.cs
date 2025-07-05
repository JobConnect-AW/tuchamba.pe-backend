using TuChambaPe.Users.Domain.Model.Aggregates;
using TuChambaPe.Users.Domain.Model.Queries;

namespace TuChambaPe.Users.Domain.Services;

/**
 * <summary>
 *     The user query service
 * </summary>
 * <remarks>
 *     This interface is used to handle user queries
 * </remarks>
 */
public interface IUserQueryService
{
    Task<User?> Handle(GetUserByUidQuery query);
    Task<User?> Handle(GetUserByAccountIdQuery query);
    Task<IEnumerable<User>> GetAllAsync();
}