using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TuChambaPe.Users.Domain.Model.Queries;
using TuChambaPe.Users.Domain.Services;
using TuChambaPe.Users.Interfaces.REST.Resources;
using TuChambaPe.Users.Interfaces.REST.Transform;

namespace TuChambaPe.Users.Interfaces.REST;

/**
 * <summary>
 *     Customers controller
 * </summary>
 * <param name="customerCommandService">Customer command service</param>
 * <param name="customerQueryService">Customer query service</param>
 */
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Customers Endpoints")]
public class CustomersController(ICustomerCommandService customerCommandService, ICustomerQueryService customerQueryService) : ControllerBase
{
    /**
     * <summary>
     *     Create customer
     * </summary>
     * <param name="createCustomerResource">Create customer resource</param>
     * <returns>Customer resource</returns>
     */
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new customer",
        Description = "Create a new customer with the provided information",
        OperationId = "CreateCustomer")]
    [SwaggerResponse(201, "Customer created successfully", typeof(CustomerResource))]
    [SwaggerResponse(400, "Bad request")]
    [SwaggerResponse(500, "Internal server error")]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerResource createCustomerResource)
    {
        var createCustomerCommand = CreateCustomerCommandFromResourceAssembler.ToCommandFromResource(createCustomerResource);
        var customer = await customerCommandService.Handle(createCustomerCommand);
        if (customer is null) return BadRequest();
        var customerResource = CustomerResourceFromEntityAssembler.ToResourceFromEntity(customer);
        return CreatedAtAction(nameof(GetCustomerByUid), new { uid = customer.Uid }, customerResource);
    }

    /**
     * <summary>
     *     Get customer by UID
     * </summary>
     * <param name="uid">Customer UID</param>
     * <returns>Customer resource</returns>
     */
    [HttpGet("{uid:guid}")]
    [SwaggerOperation(
        Summary = "Get customer by UID",
        Description = "Retrieve a specific customer by their unique identifier",
        OperationId = "GetCustomerByUid")]
    [SwaggerResponse(200, "Customer found", typeof(CustomerResource))]
    [SwaggerResponse(404, "Customer not found")]
    [SwaggerResponse(500, "Internal server error")]
    public async Task<IActionResult> GetCustomerByUid([FromRoute] Guid uid)
    {
        var getCustomerByUidQuery = new GetCustomerByUidQuery(uid);
        var customer = await customerQueryService.Handle(getCustomerByUidQuery);
        if (customer == null) return NotFound();
        var customerResource = CustomerResourceFromEntityAssembler.ToResourceFromEntity(customer);
        return Ok(customerResource);
    }

    /**
     * <summary>
     *     Get all customers
     * </summary>
     * <returns>List of customer resources</returns>
     */
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all customers",
        Description = "Retrieve a list of all customers in the system",
        OperationId = "GetAllCustomers")]
    [SwaggerResponse(200, "Customers retrieved successfully", typeof(IEnumerable<CustomerResource>))]
    [SwaggerResponse(500, "Internal server error")]
    public async Task<IActionResult> GetAllCustomers()
    {
        var customers = await customerQueryService.GetAllAsync();
        var customerResources = customers.Select(CustomerResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(customerResources);
    }
}