using TuChambaPe.IAM.Domain.Model.Aggregates;
using TuChambaPe.IAM.Domain.Model.Commands;

namespace TuChambaPe.IAM.Domain.Services;

/**
 * <summary>
 *     The account command service
 * </summary>
 * <remarks>
 *     This interface is used to handle account commands
 * </remarks>
 */
public interface IAccountCommandService
{
    /**
        * <summary>
        *     Handle sign in command
        * </summary>
        * <param name="command">The sign in command</param>
        * <returns>The authenticated account and the JWT token</returns>
        */
    Task<(Account account, string token)> Handle(SignInCommand command);

    /**
        * <summary>
        *     Handle sign up command
        * </summary>
        * <param name="command">The sign up command</param>
        * <returns>A confirmation message on successful creation.</returns>
        */
    Task Handle(SignUpCommand command);
} 