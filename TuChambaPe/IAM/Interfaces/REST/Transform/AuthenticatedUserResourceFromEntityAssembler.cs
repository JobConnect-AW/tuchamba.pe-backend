using TuChambaPe.IAM.Domain.Model.Aggregates;
using TuChambaPe.IAM.Interfaces.REST.Resources;

namespace TuChambaPe.IAM.Interfaces.REST.Transform;

public static class AuthenticatedUserResourceFromEntityAssembler
{
    public static AuthenticatedUserResource ToResourceFromEntity(
        User user, string token)
    {
        return new AuthenticatedUserResource(user.Uid, user.Email, token);
    }
}