namespace TuChambaPe.Users.Interfaces.REST.Resources;

public record CustomerResource(Guid Uid, string FirstName, string LastName, string Phone, string ProfileType, string Location, string Bio, bool IsVerified, DateTime CreatedAt, DateTime UpdatedAt);