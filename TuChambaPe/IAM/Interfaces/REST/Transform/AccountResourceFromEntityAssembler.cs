using TuChambaPe.IAM.Domain.Model.Aggregates;
using TuChambaPe.IAM.Interfaces.REST.Resources;

namespace TuChambaPe.IAM.Interfaces.REST.Transform;

public static class AccountResourceFromEntityAssembler
{
    public static AccountResource ToResourceFromEntity(Account account)
    {
        return new AccountResource(account.Uid, account.Email, account.Role);
    }
} 