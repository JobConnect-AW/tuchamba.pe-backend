namespace TuChambaPe.Users.Domain.Model.Commands;

public record UpdateCustomerCommand(Guid Uid, string? FirstName = null, string? LastName = null, string? Phone = null, string? ProfileType = null, string? Location = null, string? Bio = null);