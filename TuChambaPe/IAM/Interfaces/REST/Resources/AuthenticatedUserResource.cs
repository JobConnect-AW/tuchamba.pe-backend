namespace TuChambaPe.IAM.Interfaces.REST.Resources;

public record AuthenticatedUserResource(Guid Uid, string Email, string Token);