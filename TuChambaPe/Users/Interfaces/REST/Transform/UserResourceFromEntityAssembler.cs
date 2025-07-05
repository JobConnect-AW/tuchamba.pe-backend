using TuChambaPe.Users.Domain.Model.Aggregates;
using TuChambaPe.Users.Interfaces.REST.Resources;

namespace TuChambaPe.Users.Interfaces.REST.Transform;

/**
 * <summary>
 *     User resource from entity assembler
 * </summary>
 * <remarks>
 *     This class is used to convert a user entity to a user resource
 * </remarks>
 */
public static class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User entity)
    {
        return new UserResource(entity.Uid, entity.AccountId, entity.CustomerId, entity.WorkerId);
    }
}