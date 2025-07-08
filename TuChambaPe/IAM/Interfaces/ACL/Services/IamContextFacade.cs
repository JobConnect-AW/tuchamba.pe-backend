using TuChambaPe.IAM.Domain.Model.Commands;
using TuChambaPe.IAM.Domain.Model.Queries;
using TuChambaPe.IAM.Domain.Services;

namespace TuChambaPe.IAM.Interfaces.ACL.Services;

public class IamContextFacade(IAccountCommandService accountCommandService, IAccountQueryService accountQueryService) : IIamContextFacade
{
    public async Task<int> CreateAccount(Guid uid, string email, string password, string role)
    {
        var signUpCommand = new SignUpCommand(uid, email, password, role);
        await accountCommandService.Handle(signUpCommand);
        var getAccountByEmailQuery = new GetAccountByEmailQuery(email);
        var result = await accountQueryService.Handle(getAccountByEmailQuery);
        return result?.Id ?? 0;
    }

    public async Task<string> FetchAccountUidByEmail(string email)
    {
        var getAccountByEmailQuery = new GetAccountByEmailQuery(email);
        var result = await accountQueryService.Handle(getAccountByEmailQuery);
        return result?.Uid.ToString() ?? string.Empty;
    }

    public async Task<string> FetchEmailByAccountUid(Guid uid)
    {
        var getAccountByUidQuery = new GetAccountByUidQuery(uid);
        var result = await accountQueryService.Handle(getAccountByUidQuery);
        return result?.Email ?? string.Empty;
    }

    public async Task<string> FetchRoleByAccountUid(Guid uid)
    {
        var getAccountByUidQuery = new GetAccountByUidQuery(uid);
        var result = await accountQueryService.Handle(getAccountByUidQuery);
        return result?.Role ?? string.Empty;
    }
}