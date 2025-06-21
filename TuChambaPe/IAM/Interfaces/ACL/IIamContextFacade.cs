namespace TuChambaPe.IAM.Interfaces.ACL;

public interface IIamContextFacade
{
    Task<int> CreateUser(Guid uid, string email, string password);
    Task<string> FetchUserUidByEmail(string email);
    Task<string> FetchEmailByUserUid(Guid uid);
}