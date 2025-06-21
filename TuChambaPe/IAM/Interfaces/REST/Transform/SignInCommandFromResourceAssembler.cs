using TuChambaPe.IAM.Domain.Model.Commands;
using TuChambaPe.IAM.Interfaces.REST.Resources;

namespace TuChambaPe.IAM.Interfaces.REST.Transform;

public static class SignInCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new SignInCommand(resource.Email, resource.Password);
    }
}