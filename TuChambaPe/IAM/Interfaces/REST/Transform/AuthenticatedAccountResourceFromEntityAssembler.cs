using TuChambaPe.IAM.Domain.Model.Aggregates;
using TuChambaPe.IAM.Interfaces.REST.Resources;

namespace TuChambaPe.IAM.Interfaces.REST.Transform;

public static class AuthenticatedAccountResourceFromEntityAssembler
{
    public static AuthenticatedAccountResource ToResourceFromEntity(
        Account account, string token)
    {
        return new AuthenticatedAccountResource(account.Uid, account.Email, account.Role, token);
    }
} 