using System.Net.Mime;
using TuChambaPe.IAM.Domain.Services;
using TuChambaPe.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using TuChambaPe.IAM.Interfaces.REST.Resources;
using TuChambaPe.IAM.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace TuChambaPe.IAM.Interfaces.REST;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Authentication endpoints")]
public class AuthenticationController(IAccountCommandService accountCommandService) : ControllerBase
{
    /**
     * <summary>
     *     Sign in endpoint. It allows authenticating an account
     * </summary>
     * <param name="signInResource">The sign-in resource containing username and password.</param>
     * <returns>The authenticated account resource, including a JWT token</returns>
     */
    [HttpPost("sign-in")]
    [AllowAnonymous]
    [SwaggerOperation(
        Summary = "Sign in",
        Description = "Sign in an account",
        OperationId = "SignIn")]
    [SwaggerResponse(StatusCodes.Status200OK, "The account was authenticated", typeof(AuthenticatedAccountResource))]
    public async Task<IActionResult> SignIn([FromBody] SignInResource signInResource)
    {
        var signInCommand = SignInCommandFromResourceAssembler.ToCommandFromResource(signInResource);
        var authenticatedAccount = await accountCommandService.Handle(signInCommand);
        var resource =
            AuthenticatedAccountResourceFromEntityAssembler.ToResourceFromEntity(authenticatedAccount.account,
                authenticatedAccount.token);
        return Ok(resource);
    }

    /**
     * <summary>
     *     Sign up endpoint. It allows creating a new account
     * </summary>
     * <param name="signUpResource">The sign-up resource containing username and password.</param>
     * <returns>A confirmation message on successful creation.</returns>
     */
    [HttpPost("sign-up")]
    [AllowAnonymous]
    [SwaggerOperation(
        Summary = "Sign-up",
        Description = "Sign up a new account",
        OperationId = "SignUp")]
    [SwaggerResponse(StatusCodes.Status200OK, "The account was created successfully")]
    public async Task<IActionResult> SignUp([FromBody] SignUpResource signUpResource)
    {
        var signUpCommand = SignUpCommandFromResourceAssembler.ToCommandFromResource(signUpResource);
        await accountCommandService.Handle(signUpCommand);
        return Ok(new { message = "Account created successfully" });
    }
}