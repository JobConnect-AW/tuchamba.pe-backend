using TuChambaPe.IAM.Domain.Model.Commands;
using TuChambaPe.IAM.Domain.Model.Queries;
using TuChambaPe.IAM.Domain.Services;

namespace TuChambaPe.IAM.Interfaces.ACL.Services;

public class IamContextFacade(IUserCommandService userCommandService, IUserQueryService userQueryService) : IIamContextFacade
{
    public async Task<int> CreateUser(Guid uid, string email, string password)
    {
        var signUpCommand = new SignUpCommand(uid, email, password);
        await userCommandService.Handle(signUpCommand);
        var getUserByEmailQuery = new GetUserByEmailQuery(email);
        var result = await userQueryService.Handle(getUserByEmailQuery);
        return result?.Id ?? 0;
    }

    public async Task<string> FetchUserUidByEmail(string email)
    {
        var getUserByEmailQuery = new GetUserByEmailQuery(email);
        var result = await userQueryService.Handle(getUserByEmailQuery);
        return result?.Uid.ToString() ?? string.Empty;
    }

    public async Task<string> FetchEmailByUserUid(Guid uid)
    {
        var getUserByUidQuery = new GetUserByUidQuery(uid);
        var result = await userQueryService.Handle(getUserByUidQuery);
        return result?.Email ?? string.Empty;
    }
}