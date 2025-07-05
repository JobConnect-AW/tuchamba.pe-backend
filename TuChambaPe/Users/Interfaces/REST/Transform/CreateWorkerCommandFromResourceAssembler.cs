using TuChambaPe.Users.Domain.Model.Commands;
using TuChambaPe.Users.Interfaces.REST.Resources;

namespace TuChambaPe.Users.Interfaces.REST.Transform;

/**
 * <summary>
 *     Create worker command from resource assembler
 * </summary>
 * <remarks>
 *     This class is used to convert a create worker resource to a create worker command
 * </remarks>
 */
public static class CreateWorkerCommandFromResourceAssembler
{
    public static CreateWorkerCommand ToCommandFromResource(CreateWorkerResource resource)
    {
        return new CreateWorkerCommand(resource.Uid, resource.FirstName, resource.LastName, resource.Phone, resource.ProfileType, resource.Location, resource.Bio, resource.Skills, resource.Experience, resource.Certifications, resource.Avatar);
    }
}