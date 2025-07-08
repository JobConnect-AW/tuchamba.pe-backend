using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TuChambaPe.Payments.Domain.Model.Queries;
using TuChambaPe.Payments.Domain.Services;
using TuChambaPe.Payments.Interfaces.REST.Resources;
using TuChambaPe.Payments.Interfaces.REST.Transform;

namespace TuChambaPe.Payments.Interfaces.REST;

/// <summary>
///     The payments controller
/// </summary>
/// <param name="paymentQueryService">The IPaymentQueryService instance to query payments</param>
/// <param name="paymentCommandService">The IPaymentCommandService instance to execute commands on payments</param>
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Payment endpoints")]
public class PaymentsController(
    IPaymentQueryService paymentQueryService,
    IPaymentCommandService paymentCommandService) : ControllerBase
{
    /// <summary>
    ///     Get a payment by its UID
    /// </summary>
    /// <param name="paymentUid">The payment UID</param>
    /// <returns>The PaymentResource with the payment if found, otherwise it returns a response with NotFoundResult</returns>
    [HttpGet("{paymentUid:guid}")]
    [SwaggerOperation(
        Summary = "Get a payment by its UID",
        Description = "Get a payment by its UID",
        OperationId = "GetPaymentByUid")]
    [SwaggerResponse(StatusCodes.Status200OK, "The payment was found", typeof(PaymentResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The payment was not found")]
    public async Task<IActionResult> GetPaymentByUid([FromRoute] Guid paymentUid)
    {
        var payment = await paymentQueryService.Handle(new GetPaymentByUidQuery(paymentUid));
        if (payment is null) return NotFound();
        
        var paymentResource = PaymentResourceFromEntityAssembler.ToResourceFromEntity(payment);
        return Ok(paymentResource);
    }

    /// <summary>
    ///     Get all payments
    /// </summary>
    /// <returns>The PaymentResource collection with all payments</returns>
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all payments",
        Description = "Get all payments",
        OperationId = "GetAllPayments")]
    [SwaggerResponse(StatusCodes.Status200OK, "The payments were found", typeof(IEnumerable<PaymentResource>))]
    public async Task<IActionResult> GetAllPayments()
    {
        var getAllPaymentsQuery = new GetAllPaymentsQuery();
        var payments = await paymentQueryService.Handle(getAllPaymentsQuery);
        var paymentResources = payments.Select(PaymentResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(paymentResources);
    }

    /// <summary>
    ///     Get payments by offer UID
    /// </summary>
    /// <param name="offerUid">The offer UID</param>
    /// <returns>The PaymentResource collection with payments for the offer</returns>
    [HttpGet("by-offer/{offerUid:guid}")]
    [SwaggerOperation(
        Summary = "Get payments by offer UID",
        Description = "Get payments by offer UID",
        OperationId = "GetPaymentsByOfferUid")]
    [SwaggerResponse(StatusCodes.Status200OK, "The payments were found", typeof(IEnumerable<PaymentResource>))]
    public async Task<IActionResult> GetPaymentsByOfferUid([FromRoute] Guid offerUid)
    {
        var getPaymentsByOfferUidQuery = new GetPaymentsByOfferUidQuery(new TuChambaPe.Payments.Domain.Model.ValueObjects.OfferUid(offerUid));
        var payments = await paymentQueryService.Handle(getPaymentsByOfferUidQuery);
        var paymentResources = payments.Select(PaymentResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(paymentResources);
    }

    /// <summary>
    ///     Create a payment
    /// </summary>
    /// <param name="resource">The CreatePaymentResource with the payment data to create</param>
    /// <returns>The PaymentResource with the payment created if successful, otherwise it returns a response with BadRequestResult</returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a payment",
        Description = "Create a payment",
        OperationId = "CreatePayment")]
    [SwaggerResponse(StatusCodes.Status201Created, "The payment was created", typeof(PaymentResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The payment was not created")]
    public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentResource resource)
    {
        var createPaymentCommand = CreatePaymentCommandFromResourceAssembler.ToCommandFromResource(resource);
        var payment = await paymentCommandService.Handle(createPaymentCommand);
        if (payment is null) return BadRequest();
        
        var paymentResource = PaymentResourceFromEntityAssembler.ToResourceFromEntity(payment);
        return CreatedAtAction(nameof(GetPaymentByUid), new { paymentUid = payment.Uid }, paymentResource);
    }

    /// <summary>
    ///     Update payment status
    /// </summary>
    /// <param name="paymentUid">The payment UID</param>
    /// <param name="resource">The UpdatePaymentStatusResource with the new status</param>
    /// <returns>The PaymentResource with the updated payment if successful, otherwise it returns a response with BadRequestResult</returns>
    [HttpPut("{paymentUid:guid}/status")]
    [SwaggerOperation(
        Summary = "Update payment status",
        Description = "Update payment status",
        OperationId = "UpdatePaymentStatus")]
    [SwaggerResponse(StatusCodes.Status200OK, "The payment status was updated", typeof(PaymentResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The payment status was not updated")]
    public async Task<IActionResult> UpdatePaymentStatus(
        [FromRoute] Guid paymentUid,
        [FromBody] UpdatePaymentStatusResource resource)
    {
        var updatePaymentStatusCommand = UpdatePaymentStatusCommandFromResourceAssembler.ToCommandFromResource(resource, paymentUid);
        var payment = await paymentCommandService.Handle(updatePaymentStatusCommand);
        if (payment is null) return BadRequest();
        
        var paymentResource = PaymentResourceFromEntityAssembler.ToResourceFromEntity(payment);
        return Ok(paymentResource);
    }

    /// <summary>
    ///     Verify payment
    /// </summary>
    /// <param name="paymentUid">The payment UID</param>
    /// <param name="resource">The VerifyPaymentResource with verification data</param>
    /// <returns>The PaymentResource with the verified payment if successful, otherwise it returns a response with BadRequestResult</returns>
    [HttpPut("{paymentUid:guid}/verify")]
    [SwaggerOperation(
        Summary = "Verify payment",
        Description = "Verify payment by worker or customer",
        OperationId = "VerifyPayment")]
    [SwaggerResponse(StatusCodes.Status200OK, "The payment was verified", typeof(PaymentResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The payment was not verified")]
    public async Task<IActionResult> VerifyPayment(
        [FromRoute] Guid paymentUid,
        [FromBody] VerifyPaymentResource resource)
    {
        var verifyPaymentCommand = VerifyPaymentCommandFromResourceAssembler.ToCommandFromResource(resource, paymentUid);
        var payment = await paymentCommandService.Handle(verifyPaymentCommand);
        if (payment is null) return BadRequest();
        
        var paymentResource = PaymentResourceFromEntityAssembler.ToResourceFromEntity(payment);
        return Ok(paymentResource);
    }
} 