namespace TuChambaPe.Users.Domain.Model.Commands;

public record CreateCustomerCommand(Guid Uid, Guid UserUid, string FirstName, string LastName, string Phone, string ProfileType, string Location, string Bio);