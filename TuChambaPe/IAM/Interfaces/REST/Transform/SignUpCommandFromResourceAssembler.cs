using TuChambaPe.IAM.Domain.Model.Commands;
using TuChambaPe.IAM.Interfaces.REST.Resources;

namespace TuChambaPe.IAM.Interfaces.REST.Transform;

public static class SignUpCommandFromResourceAssembler
{
    public static SignUpCommand ToCommandFromResource(SignUpResource resource)
    {
        return new SignUpCommand(resource.Uid, resource.Email, resource.Password, resource.Role);
    }
}