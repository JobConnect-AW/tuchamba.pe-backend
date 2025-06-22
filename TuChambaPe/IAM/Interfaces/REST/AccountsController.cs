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
 *     The accounts controller
 * </summary>
 * <remarks>
 *     This class is used to handle account requests
 * </remarks>
 */
[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Account endpoints")]
public class AccountsController(IAccountQueryService accountQueryService) : ControllerBase
{
    /**
     * <summary>
     *     Get account by uid endpoint. It allows to get an account by id
     * </summary>
     * <param name="uid">The account uid</param>
     * <returns>The account resource</returns>
     */
    [HttpGet("{uid}")]
    [SwaggerOperation(
        Summary = "Get an account by its uid",
        Description = "Get an account by its uid",
        OperationId = "GetAccountByUid")]
    [SwaggerResponse(StatusCodes.Status200OK, "The account was found", typeof(AccountResource))]
    public async Task<IActionResult> GetAccountByUid(Guid uid)
    {
        var getAccountByIdQuery = new GetAccountByUidQuery(uid);
        var account = await accountQueryService.Handle(getAccountByIdQuery);
        var accountResource = AccountResourceFromEntityAssembler.ToResourceFromEntity(account!);
        return Ok(accountResource);
    }

    /**
     * <summary>
     *     Get all accounts' endpoint. It allows getting all accounts
     * </summary>
     * <returns>The account resources</returns>
     */
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all accounts",
        Description = "Get all accounts",
        OperationId = "GetAllAccounts")]
    [SwaggerResponse(StatusCodes.Status200OK, "The accounts were found", typeof(IEnumerable<AccountResource>))]
    public async Task<IActionResult> GetAllAccounts()
    {
        var getAllAccountsQuery = new GetAllAccountsQuery();
        var accounts = await accountQueryService.Handle(getAllAccountsQuery);
        var accountResources = accounts.Select(AccountResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(accountResources);
    }
} 