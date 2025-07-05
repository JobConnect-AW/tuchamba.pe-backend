using TuChambaPe.Users.Domain.Model.Commands;
using TuChambaPe.Users.Interfaces.REST.Resources;

namespace TuChambaPe.Users.Interfaces.REST.Transform;

/**
 * <summary>
 *     Create user command from resource assembler
 * </summary>
 * <remarks>
 *     This class is used to convert a create user resource to a create user command
 * </remarks>
 */
public static class CreateUserCommandFromResourceAssembler
{
    public static CreateUserCommand ToCommandFromResource(CreateUserResource resource)
    {
        return new CreateUserCommand(resource.Uid, resource.AccountId);
    }
}