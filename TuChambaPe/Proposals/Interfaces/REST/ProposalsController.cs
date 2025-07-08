using System.Net.Mime;
using TuChambaPe.Proposals.Domain.Model.Commands;
using TuChambaPe.Proposals.Domain.Model.Queries;
using TuChambaPe.Proposals.Domain.Services;
using TuChambaPe.Proposals.Interfaces.REST.Resources;
using TuChambaPe.Proposals.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace TuChambaPe.Proposals.Interfaces.REST;

/**
 * <summary>
 *     The proposals controller
 * </summary>
 * <remarks>
 *     This class is used to handle proposal requests
 * </remarks>
 */
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Proposal endpoints")]
public class ProposalsController(
    IProposalQueryService proposalQueryService,
    IProposalCommandService proposalCommandService) : ControllerBase
{
    /**
     * <summary>
     *     Get proposal by uid endpoint. It allows to get a proposal by uid
     * </summary>
     * <param name="uid">The proposal uid</param>
     * <returns>The proposal resource</returns>
     */
    [HttpGet("{uid}")]
    [SwaggerOperation(
        Summary = "Get a proposal by its uid",
        Description = "Get a proposal by its uid",
        OperationId = "GetProposalByUid")]
    [SwaggerResponse(StatusCodes.Status200OK, "The proposal was found", typeof(ProposalResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The proposal was not found")]
    public async Task<IActionResult> GetProposalByUid(Guid uid)
    {
        var getProposalByIdQuery = new GetProposalById(uid);
        var proposal = await proposalQueryService.Handle(getProposalByIdQuery);
        
        if (proposal == null)
            return NotFound();
            
        var proposalResource = ProposalResourceFromEntityAssembler.ToResourceFromEntity(proposal);
        return Ok(proposalResource);
    }

    /**
     * <summary>
     *     Get all proposals endpoint. It allows getting all proposals
     * </summary>
     * <returns>The proposal resources</returns>
     */
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all proposals",
        Description = "Get all proposals",
        OperationId = "GetAllProposals")]
    [SwaggerResponse(StatusCodes.Status200OK, "The proposals were found", typeof(IEnumerable<ProposalResource>))]
    public async Task<IActionResult> GetAllProposals()
    {
        var getAllProposalsQuery = new GetAllProposalsQuery();
        var proposals = await proposalQueryService.Handle(getAllProposalsQuery);
        var proposalResources = proposals.Select(ProposalResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(proposalResources);
    }

    /**
     * <summary>
     *     Get proposals by worker uid endpoint. It allows getting proposals by worker uid
     * </summary>
     * <param name="workerUid">The worker uid</param>
     * <returns>The proposal resources</returns>
     */
    [HttpGet("worker/{workerUid}")]
    [SwaggerOperation(
        Summary = "Get proposals by worker uid",
        Description = "Get proposals by worker uid",
        OperationId = "GetProposalsByWorkerUid")]
    [SwaggerResponse(StatusCodes.Status200OK, "The proposals were found", typeof(IEnumerable<ProposalResource>))]
    public async Task<IActionResult> GetProposalsByWorkerUid(Guid workerUid)
    {
        var getProposalsByWorkerIdQuery = new GetProposalsByWorkerId(workerUid);
        var proposals = await proposalQueryService.Handle(getProposalsByWorkerIdQuery);
        var proposalResources = proposals.Select(ProposalResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(proposalResources);
    }

    /**
     * <summary>
     *     Get proposals by offer uid endpoint. It allows getting proposals by offer uid
     * </summary>
     * <param name="offerUid">The offer uid</param>
     * <returns>The proposal resources</returns>
     */
    [HttpGet("offer/{offerUid}")]
    [SwaggerOperation(
        Summary = "Get proposals by offer uid",
        Description = "Get proposals by offer uid",
        OperationId = "GetProposalsByOfferUid")]
    [SwaggerResponse(StatusCodes.Status200OK, "The proposals were found", typeof(IEnumerable<ProposalResource>))]
    public async Task<IActionResult> GetProposalsByOfferUid(Guid offerUid)
    {
        var getProposalsByOfferIdQuery = new GetProposalsByOfferId(offerUid);
        var proposals = await proposalQueryService.Handle(getProposalsByOfferIdQuery);
        var proposalResources = proposals.Select(ProposalResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(proposalResources);
    }

    /**
     * <summary>
     *     Create proposal endpoint. It allows creating a new proposal
     * </summary>
     * <param name="resource">The create proposal resource</param>
     * <returns>The created proposal resource</returns>
     */
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new proposal",
        Description = "Create a new proposal",
        OperationId = "CreateProposal")]
    [SwaggerResponse(StatusCodes.Status201Created, "The proposal was created", typeof(ProposalResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid proposal data")]
    public async Task<IActionResult> CreateProposal([FromBody] CreateProposalResource resource)
    {
        var createProposalCommand = CreateProposalCommandFromResourceAssembler.ToCommandFromResource(resource);
        var proposal = await proposalCommandService.Handle(createProposalCommand);
        var proposalResource = ProposalResourceFromEntityAssembler.ToResourceFromEntity(proposal);
        return CreatedAtAction(nameof(GetProposalByUid), new { uid = proposal.Uid }, proposalResource);
    }

    /**
     * <summary>
     *     Update proposal endpoint. It allows updating an existing proposal
     * </summary>
     * <param name="uid">The proposal uid</param>
     * <param name="resource">The update proposal resource</param>
     * <returns>No content</returns>
     */
    [HttpPut("{uid}")]
    [SwaggerOperation(
        Summary = "Update a proposal",
        Description = "Update a proposal",
        OperationId = "UpdateProposal")]
    [SwaggerResponse(StatusCodes.Status204NoContent, "The proposal was updated")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The proposal was not found")]
    public async Task<IActionResult> UpdateProposal(Guid uid, [FromBody] UpdateProposalResource resource)
    {
        var updateProposalCommand = UpdateProposalCommandFromResourceAssembler.ToCommandFromResource(uid, resource);
        await proposalCommandService.Handle(updateProposalCommand);
        return NoContent();
    }

    /**
     * <summary>
     *     Delete proposal endpoint. It allows deleting a proposal
     * </summary>
     * <param name="uid">The proposal uid</param>
     * <returns>No content</returns>
     */
    [HttpDelete("{uid}")]
    [SwaggerOperation(
        Summary = "Delete a proposal",
        Description = "Delete a proposal",
        OperationId = "DeleteProposal")]
    [SwaggerResponse(StatusCodes.Status204NoContent, "The proposal was deleted")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The proposal was not found")]
    public async Task<IActionResult> DeleteProposal(Guid uid)
    {
        var deleteProposalCommand = new DeleteProposalCommand(uid);
        await proposalCommandService.Handle(deleteProposalCommand);
        return NoContent();
    }
} 