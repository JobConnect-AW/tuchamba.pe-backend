namespace TuChambaPe.Users.Interfaces.REST.Resources;


public record CreateWorkerResource(Guid Uid, Guid UserUid, string FirstName, string LastName, string Phone, string ProfileType, string Location, string Bio, List<string> Skills, int Experience, List<string> Certifications, string? Avatar = null);