using TuChambaPe.IAM.Domain.Model.Events;
using TuChambaPe.Users.Domain.Model.Commands;
using TuChambaPe.Users.Domain.Services;
using TuChambaPe.Shared.Application.Internal.EventHandlers;

namespace TuChambaPe.Users.Application.Internal.EventHandlers;

/// <summary>
///     Event handler for AccountCreatedEvent
/// </summary>
/// <param name="userCommandService">The user command service</param>
public class AccountCreatedEventHandler(IUserCommandService userCommandService) : IEventHandler<AccountCreatedEvent>
{
    /// <inheritdoc />
    public async Task Handle(AccountCreatedEvent notification, CancellationToken cancellationToken)
    {
        // Create a new user when an account is created
        var createUserCommand = new CreateUserCommand(
            Guid.NewGuid(), // Generate new UID for user
            notification.AccountUid 
        );
        
        await userCommandService.Handle(createUserCommand);
    }
} 