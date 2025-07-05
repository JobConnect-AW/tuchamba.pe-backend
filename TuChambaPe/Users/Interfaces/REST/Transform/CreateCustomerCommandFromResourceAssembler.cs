using TuChambaPe.Users.Domain.Model.Commands;
using TuChambaPe.Users.Interfaces.REST.Resources;

namespace TuChambaPe.Users.Interfaces.REST.Transform;

/**
 * <summary>
 *     Create customer command from resource assembler
 * </summary>
 * <remarks>
 *     This class is used to convert a create customer resource to a create customer command
 * </remarks>
 */
public static class CreateCustomerCommandFromResourceAssembler
{
    public static CreateCustomerCommand ToCommandFromResource(CreateCustomerResource resource)
    {
        return new CreateCustomerCommand(resource.Uid, resource.FirstName, resource.LastName, resource.Phone, resource.ProfileType, resource.Location, resource.Bio);
    }
}