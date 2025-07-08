namespace TuChambaPe.Users.Interfaces.REST.Resources;

/// <summary>
///     Resource for creating a user
/// </summary>
/// <param name="Uid">The user UID</param>
/// <param name="AccountId">The account ID</param>
/// <param name="Email">The user email</param>
/// <param name="Role">The user role</param>
public record CreateUserResource(Guid Uid, Guid AccountId, string Email, string Role);