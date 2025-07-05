using TuChambaPe.Users.Domain.Model.Aggregates;
using TuChambaPe.Users.Domain.Model.Commands;
using TuChambaPe.Users.Domain.Repositories;
using TuChambaPe.Users.Domain.Services;
using TuChambaPe.Shared.Domain.Repositories;

namespace TuChambaPe.Users.Application.Internal.CommandServices;

/**
 * <summary>
 *     The user command service
 * </summary>
 * <remarks>
 *     This service is used to handle user commands
 * </remarks>
 */
public class UserCommandService(IUserRepository userRepository, IUnitOfWork unitOfWork) : IUserCommandService
{
    /**
     * <summary>
     *     Handle create user command
     * </summary>
     * <param name="command">The create user command</param>
     * <returns>The created user</returns>
     */
    public async Task<User> Handle(CreateUserCommand command)
    {
        // Check if user already exists with this account id
        if (userRepository.ExistsByAccountId(command.AccountId))
            throw new InvalidOperationException("User with this account id already exists");

        var user = new User(command.Uid, command.AccountId);
        await userRepository.AddAsync(user);
        await unitOfWork.CompleteAsync();
        return user;
    }
}