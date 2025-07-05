namespace TuChambaPe.Users.Domain.Model.Commands;

public record CreateCustomerCommand(Guid Uid, string FirstName, string LastName, string Phone, string ProfileType, string Location, string Bio);