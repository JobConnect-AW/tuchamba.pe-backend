namespace TuChambaPe.Users.Domain.Model.Commands;

public record CreateUserCommand(Guid Uid, Guid AccountId);