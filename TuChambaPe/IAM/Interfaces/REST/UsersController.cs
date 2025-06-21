using System.Net.Mime;
using TuChambaPe.IAM.Domain.Model.Queries;
using TuChambaPe.IAM.Domain.Services;
using TuChambaPe.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using TuChambaPe.IAM.Interfaces.REST.Resources;
using TuChambaPe.IAM.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace TuChambaPe.IAM.Interfaces.REST;

/**
 * <summary>
 *     The user's controller
 * </summary>
 * <remarks>
 *     This class is used to handle user requests
 * </remarks>
 */
[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available User endpoints")]
public class UsersController(IUserQueryService userQueryService) : ControllerBase
{
    /**
     * <summary>
     *     Get user by uid endpoint. It allows to get a user by id
     * </summary>
     * <param name="uid">The user uid</param>
     * <returns>The user resource</returns>
     */
    [HttpGet("{uid}")]
    [SwaggerOperation(
        Summary = "Get a user by its uid",
        Description = "Get a user by its uid",
        OperationId = "GetUserByUid")]
    [SwaggerResponse(StatusCodes.Status200OK, "The user was found", typeof(UserResource))]
    public async Task<IActionResult> GetUserByUid(Guid uid)
    {
        var getUserByIdQuery = new GetUserByUidQuery(uid);
        var user = await userQueryService.Handle(getUserByIdQuery);
        var userResource = UserResourceFromEntityAssembler.ToResourceFromEntity(user!);
        return Ok(userResource);
    }

    /**
     * <summary>
     *     Get all users' endpoint. It allows getting all users
     * </summary>
     * <returns>The user resources</returns>
     */
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all users",
        Description = "Get all users",
        OperationId = "GetAllUsers")]
    [SwaggerResponse(StatusCodes.Status200OK, "The users were found", typeof(IEnumerable<UserResource>))]
    public async Task<IActionResult> GetAllUsers()
    {
        var getAllUsersQuery = new GetAllUsersQuery();
        var users = await userQueryService.Handle(getAllUsersQuery);
        var userResources = users.Select(UserResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(userResources);
    }
}