namespace TuChambaPe.Users.Interfaces.REST.Resources;

public record CreateCustomerResource(Guid Uid, Guid UserUid, string FirstName, string LastName, string Phone, string ProfileType, string Location, string Bio);