using TuChambaPe.Shared.Domain.Model.Events;

namespace TuChambaPe.IAM.Domain.Model.Events;

/// <summary>
///     Event that is published when an account is created
/// </summary>
/// <param name="AccountUid">The UID of the created account</param>
/// <param name="Email">The email of the created account</param>
/// <param name="Role">The role of the created account</param>
/// <param name="CreatedAt">The creation timestamp</param>
public record AccountCreatedEvent(Guid AccountUid, string Role, DateTime CreatedAt) : IEvent; 