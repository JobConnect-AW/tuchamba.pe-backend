namespace TuChambaPe.IAM.Interfaces.ACL;

public interface IIamContextFacade
{
    Task<int> CreateAccount(Guid uid, string email, string password);
    Task<string> FetchAccountUidByEmail(string email);
    Task<string> FetchEmailByAccountUid(Guid uid);
}