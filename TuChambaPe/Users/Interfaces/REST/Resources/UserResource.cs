namespace TuChambaPe.Users.Interfaces.REST.Resources;

/// <summary>
///     Resource for user information
/// </summary>
/// <param name="Uid">The user UID</param>
/// <param name="AccountId">The account ID</param>
/// <param name="CustomerId">The customer ID if applicable</param>
/// <param name="WorkerId">The worker ID if applicable</param>
public record UserResource(Guid Uid, Guid AccountId, Guid? CustomerId, Guid? WorkerId);