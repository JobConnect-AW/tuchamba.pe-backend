using System.Net.Mime;
using TuChambaPe.Offers.Domain.Model.Commands;
using TuChambaPe.Offers.Domain.Model.Queries;
using TuChambaPe.Offers.Domain.Services;
using TuChambaPe.Offers.Interfaces.REST.Resources;
using TuChambaPe.Offers.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace TuChambaPe.Offers.Interfaces.REST;

/**
 * <summary>
 *     The offers controller
 * </summary>
 * <remarks>
 *     This class is used to handle offer requests
 * </remarks>
 */
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Offer endpoints")]
public class OffersController(
    IOfferQueryService offerQueryService,
    IOfferCommandService offerCommandService) : ControllerBase
{
    /**
     * <summary>
     *     Get offer by uid endpoint. It allows to get an offer by uid
     * </summary>
     * <param name="uid">The offer uid</param>
     * <returns>The offer resource</returns>
     */
    [HttpGet("{uid}")]
    [SwaggerOperation(
        Summary = "Get an offer by its uid",
        Description = "Get an offer by its uid",
        OperationId = "GetOfferByUid")]
    [SwaggerResponse(StatusCodes.Status200OK, "The offer was found", typeof(OfferResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The offer was not found")]
    public async Task<IActionResult> GetOfferByUid(Guid uid)
    {
        var getOfferByIdQuery = new GetOfferById(uid);
        var offer = await offerQueryService.Handle(getOfferByIdQuery);
        
        if (offer == null)
            return NotFound();
            
        var offerResource = OfferResourceFromEntityAssembler.ToResourceFromEntity(offer);
        return Ok(offerResource);
    }

    /**
     * <summary>
     *     Get all offers endpoint. It allows getting all offers
     * </summary>
     * <returns>The offer resources</returns>
     */
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all offers",
        Description = "Get all offers",
        OperationId = "GetAllOffers")]
    [SwaggerResponse(StatusCodes.Status200OK, "The offers were found", typeof(IEnumerable<OfferResource>))]
    public async Task<IActionResult> GetAllOffers()
    {
        var getAllOffersQuery = new GetAllOffersQuery();
        var offers = await offerQueryService.Handle(getAllOffersQuery);
        var offerResources = offers.Select(OfferResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(offerResources);
    }

    /**
     * <summary>
     *     Create offer endpoint. It allows creating a new offer
     * </summary>
     * <param name="resource">The create offer resource</param>
     * <returns>The created offer resource</returns>
     */
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new offer",
        Description = "Create a new offer",
        OperationId = "CreateOffer")]
    [SwaggerResponse(StatusCodes.Status201Created, "The offer was created", typeof(OfferResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid offer data")]
    public async Task<IActionResult> CreateOffer([FromBody] CreateOfferResource resource)
    {
        var createOfferCommand = CreateOfferCommandFromResourceAssembler.ToCommandFromResource(resource);
        var offer = await offerCommandService.Handle(createOfferCommand);
        var offerResource = OfferResourceFromEntityAssembler.ToResourceFromEntity(offer);
        return CreatedAtAction(nameof(GetOfferByUid), new { uid = offer.Uid }, offerResource);
    }

    /**
     * <summary>
     *     Update offer endpoint. It allows updating an existing offer
     * </summary>
     * <param name="uid">The offer uid</param>
     * <param name="resource">The update offer resource</param>
     * <returns>No content</returns>
     */
    [HttpPut("{uid}")]
    [SwaggerOperation(
        Summary = "Update an offer",
        Description = "Update an offer",
        OperationId = "UpdateOffer")]
    [SwaggerResponse(StatusCodes.Status204NoContent, "The offer was updated")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The offer was not found")]
    public async Task<IActionResult> UpdateOffer(Guid uid, [FromBody] UpdateOfferResource resource)
    {
        var updateOfferCommand = UpdateOfferCommandFromResourceAssembler.ToCommandFromResource(uid, resource);
        await offerCommandService.Handle(updateOfferCommand);
        return NoContent();
    }

    /**
     * <summary>
     *     Delete offer endpoint. It allows deleting an offer
     * </summary>
     * <param name="uid">The offer uid</param>
     * <returns>No content</returns>
     */
    [HttpDelete("{uid}")]
    [SwaggerOperation(
        Summary = "Delete an offer",
        Description = "Delete an offer",
        OperationId = "DeleteOffer")]
    [SwaggerResponse(StatusCodes.Status204NoContent, "The offer was deleted")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The offer was not found")]
    public async Task<IActionResult> DeleteOffer(Guid uid)
    {
        var deleteOfferCommand = new DeleteOfferCommand(uid);
        await offerCommandService.Handle(deleteOfferCommand);
        return NoContent();
    }
}
