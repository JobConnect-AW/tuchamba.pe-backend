using Cortex.Mediator;
using TuChambaPe.IAM.Application.Internal.OutboundServices;
using TuChambaPe.IAM.Domain.Model.Aggregates;
using TuChambaPe.IAM.Domain.Model.Commands;
using TuChambaPe.IAM.Domain.Model.Events;
using TuChambaPe.IAM.Domain.Repositories;
using TuChambaPe.IAM.Domain.Services;
using TuChambaPe.Shared.Domain.Repositories;
using Cortex.Mediator.Notifications;

namespace TuChambaPe.IAM.Application.Internal.CommandServices;

/**
 * <summary>
 *     The account command service
 * </summary>
 * <remarks>
 *     This class is used to handle account commands
 * </remarks>
 */
public class AccountCommandService(
    IAccountRepository accountRepository,
    ITokenService tokenService,
    IHashingService hashingService,
    IUnitOfWork unitOfWork,
    IMediator notificationPublisher)
    : IAccountCommandService
{
    /**
     * <summary>
     *     Handle sign in command
     * </summary>
     * <param name="command">The sign in command</param>
     * <returns>The authenticated account and the JWT token</returns>
     */
    public async Task<(Account account, string token)> Handle(SignInCommand command)
    {
        var account = await accountRepository.FindByEmailAsync(command.Email);

        if (account == null || !hashingService.VerifyPassword(command.Password, account.PasswordHash))
            throw new Exception("Invalid email or password");

        var token = tokenService.GenerateToken(account);

        return (account, token);
    }

    /**
     * <summary>
     *     Handle sign up command
     * </summary>
     * <param name="command">The sign up command</param>
     * <returns>A confirmation message on successful creation.</returns>
     */
    public async Task Handle(SignUpCommand command)
    {
        if (accountRepository.ExistsByEmail(command.Email))
            throw new Exception($"Email {command.Email} is already taken");

        var hashedPassword = hashingService.HashPassword(command.Password);
        var account = new Account(command.Uid, command.Email, hashedPassword, command.Role);
        try
        {
            await accountRepository.AddAsync(account);
            await unitOfWork.CompleteAsync();
            
            // Publish AccountCreatedEvent after successful account creation
            var accountCreatedEvent = new AccountCreatedEvent(
                account.Uid,
                account.Role, 
                DateTime.UtcNow);
            
            await notificationPublisher.PublishAsync(accountCreatedEvent);
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while creating account: {e.Message}");
        }
    }
} 