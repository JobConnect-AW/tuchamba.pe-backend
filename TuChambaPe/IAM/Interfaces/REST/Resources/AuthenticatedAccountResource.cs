namespace TuChambaPe.IAM.Interfaces.REST.Resources;

public record AuthenticatedAccountResource(Guid Uid, string Email, string Token); 