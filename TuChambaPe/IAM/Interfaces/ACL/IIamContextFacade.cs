namespace TuChambaPe.IAM.Interfaces.ACL;

public interface IIamContextFacade
{
    Task<int> CreateAccount(Guid uid, string email, string password, string role);
    Task<string> FetchAccountUidByEmail(string email);
    Task<string> FetchEmailByAccountUid(Guid uid);
    Task<string> FetchRoleByAccountUid(Guid uid);
}