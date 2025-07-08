namespace TuChambaPe.Users.Domain.Model.Commands;

/// <summary>
///     Command to create a user
/// </summary>
/// <param name="Uid">The user UID</param>
/// <param name="AccountId">The account ID</param>
public record CreateUserCommand(Guid Uid, Guid AccountId);