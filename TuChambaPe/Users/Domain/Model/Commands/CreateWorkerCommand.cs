namespace TuChambaPe.Users.Domain.Model.Commands;

public record CreateWorkerCommand(Guid Uid, Guid UserUid, string FirstName, string LastName, string Phone, string ProfileType, string Location, string Bio, List<string> Skills, int Experience, List<string> Certifications, string? Avatar = null);