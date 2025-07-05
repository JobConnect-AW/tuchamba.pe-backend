using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TuChambaPe.Users.Domain.Model.Commands;
using TuChambaPe.Users.Domain.Model.Queries;
using TuChambaPe.Users.Domain.Services;
using TuChambaPe.Users.Interfaces.REST.Resources;
using TuChambaPe.Users.Interfaces.REST.Transform;

namespace TuChambaPe.Users.Interfaces.REST;

/**
 * <summary>
 *     Users controller
 * </summary>
 * <remarks>
 *     This controller is used to handle user requests
 * </remarks>
 */
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available User endpoints")]
public class UsersController(IUserCommandService userCommandService, IUserQueryService userQueryService) : ControllerBase
{
    /**
     * <summary>
     *     Create a new user
     * </summary>
     * <param name="resource">The create user resource</param>
     * <returns>The created user resource</returns>
     */
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new user",
        Description = "Create a new user",
        OperationId = "CreateUser")]
    [SwaggerResponse(StatusCodes.Status201Created, "The user was created", typeof(UserResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid user data")]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserResource resource)
    {
        var createUserCommand = CreateUserCommandFromResourceAssembler.ToCommandFromResource(resource);
        var user = await userCommandService.Handle(createUserCommand);
        var userResource = UserResourceFromEntityAssembler.ToResourceFromEntity(user);
        return CreatedAtAction(nameof(GetUserByUid), new { uid = user.Uid }, userResource);
    }

    /**
     * <summary>
     *     Get user by UID
     * </summary>
     * <param name="uid">The user UID</param>
     * <returns>The user resource</returns>
     */
    [HttpGet("{uid:guid}")]
    [SwaggerOperation(
        Summary = "Get a user by its uid",
        Description = "Get a user by its uid",
        OperationId = "GetUserByUid")]
    [SwaggerResponse(StatusCodes.Status200OK, "The user was found", typeof(UserResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The user was not found")]
    public async Task<IActionResult> GetUserByUid(Guid uid)
    {
        var getUserByUidQuery = new GetUserByUidQuery(uid);
        var user = await userQueryService.Handle(getUserByUidQuery);
        if (user == null) return NotFound();
        var userResource = UserResourceFromEntityAssembler.ToResourceFromEntity(user);
        return Ok(userResource);
    }

    /**
     * <summary>
     *     Get user by account ID
     * </summary>
     * <param name="accountId">The account ID</param>
     * <returns>The user resource</returns>
     */
    [HttpGet("account/{accountId:guid}")]
    [SwaggerOperation(
        Summary = "Get a user by its account id",
        Description = "Get a user by its account id",
        OperationId = "GetUserByAccountId")]
    [SwaggerResponse(StatusCodes.Status200OK, "The user was found", typeof(UserResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The user was not found")]
    public async Task<IActionResult> GetUserByAccountId(Guid accountId)
    {
        var getUserByAccountIdQuery = new GetUserByAccountIdQuery(accountId);
        var user = await userQueryService.Handle(getUserByAccountIdQuery);
        if (user == null) return NotFound();
        var userResource = UserResourceFromEntityAssembler.ToResourceFromEntity(user);
        return Ok(userResource);
    }

    /**
     * <summary>
     *     Get all users
     * </summary>
     * <returns>List of user resources</returns>
     */
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all users",
        Description = "Get all users",
        OperationId = "GetAllUsers")]
    [SwaggerResponse(StatusCodes.Status200OK, "The users were found", typeof(IEnumerable<UserResource>))]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await userQueryService.GetAllAsync();
        var userResources = users.Select(UserResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(userResources);
    }
}