using TuChambaPe.Users.Domain.Model.Aggregates;
using TuChambaPe.Users.Domain.Model.Commands;

namespace TuChambaPe.Users.Domain.Services;


public interface IUserCommandService
{
    Task<User> Handle(CreateUserCommand command);
}