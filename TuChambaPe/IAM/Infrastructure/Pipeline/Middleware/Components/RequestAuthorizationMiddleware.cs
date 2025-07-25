using TuChambaPe.IAM.Application.Internal.OutboundServices;
using TuChambaPe.IAM.Domain.Model.Queries;
using TuChambaPe.IAM.Domain.Services;
using TuChambaPe.IAM.Infrastructure.Pipeline.Middleware.Attributes;

namespace TuChambaPe.IAM.Infrastructure.Pipeline.Middleware.Components;

/**
 * RequestAuthorizationMiddleware is a custom middleware.
 * This middleware is used to authorize requests.
 * It validates a token is included in the request header and that the token is valid.
 * If the token is valid then it sets the user in HttpContext.Items["User"].
 */
public class RequestAuthorizationMiddleware(RequestDelegate next)
{
    /**
     * InvokeAsync is called by the ASP.NET Core runtime.
     * It is used to authorize requests.
     * It validates a token is included in the request header and that the token is valid.
     * If the token is valid then it sets the user in HttpContext.Items["User"].
     */
    public async Task InvokeAsync(
        HttpContext context,
        IAccountQueryService userQueryService,
        ITokenService tokenService)
    {
        Console.WriteLine("Entering InvokeAsync");
        // skip authorization if endpoint is decorated with [AllowAnonymous] attribute
        var allowAnonymous = context.Request.HttpContext.GetEndpoint()!.Metadata
            .Any(m => m.GetType() == typeof(AllowAnonymousAttribute));
        Console.WriteLine($"Allow Anonymous is {allowAnonymous}");
        if (allowAnonymous)
        {
            Console.WriteLine("Skipping authorization");
            // [AllowAnonymous] attribute is set, so skip authorization
            await next(context);
            return;
        }
        Console.WriteLine("Entering authorization");
        // get token from request header
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();


        // if token is null then throw exception
        if (token == null) throw new Exception("Null or invalid token");

        // validate token
        var userUid = await tokenService.ValidateToken(token) ?? throw new Exception("Invalid token");

        // get user by id
        var getUserByIdQuery = new GetAccountByUidQuery(userUid);

        // set user in HttpContext.Items["User"]
        var user = await userQueryService.Handle(getUserByIdQuery);
        Console.WriteLine("Successful authorization. Updating Context...");
        context.Items["User"] = user; // user;
        Console.WriteLine("Continuing with Middleware Pipeline");
        // call next middleware
        if (context.Request.Method == HttpMethods.Options)
        {
            Console.WriteLine("Skipping authorization for OPTIONS request");

        }
        await next(context);
        return;

    }
}