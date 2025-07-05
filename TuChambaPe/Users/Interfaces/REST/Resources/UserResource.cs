namespace TuChambaPe.Users.Interfaces.REST.Resources;

public record UserResource(Guid Uid, Guid AccountId, Guid? CustomerId, Guid? WorkerId);