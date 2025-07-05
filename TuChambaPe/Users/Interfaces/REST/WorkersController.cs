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
 *     Workers controller
 * </summary>
 * <param name="workerCommandService">Worker command service</param>
 * <param name="workerQueryService">Worker query service</param>
 */
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Workers Endpoints")]
public class WorkersController(IWorkerCommandService workerCommandService, IWorkerQueryService workerQueryService) : ControllerBase
{
    /**
     * <summary>
     *     Create worker
     * </summary>
     * <param name="createWorkerResource">Create worker resource</param>
     * <returns>Worker resource</returns>
     */
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new worker",
        Description = "Create a new worker with the provided information",
        OperationId = "CreateWorker")]
    [SwaggerResponse(201, "Worker created successfully", typeof(WorkerResource))]
    [SwaggerResponse(400, "Bad request")]
    [SwaggerResponse(500, "Internal server error")]
    public async Task<IActionResult> CreateWorker([FromBody] CreateWorkerResource createWorkerResource)
    {
        var createWorkerCommand = CreateWorkerCommandFromResourceAssembler.ToCommandFromResource(createWorkerResource);
        var worker = await workerCommandService.Handle(createWorkerCommand);
        if (worker is null) return BadRequest();
        var workerResource = WorkerResourceFromEntityAssembler.ToResourceFromEntity(worker);
        return CreatedAtAction(nameof(GetWorkerByUid), new { uid = worker.Uid }, workerResource);
    }

    /**
     * <summary>
     *     Get worker by UID
     * </summary>
     * <param name="uid">Worker UID</param>
     * <returns>Worker resource</returns>
     */
    [HttpGet("{uid:guid}")]
    [SwaggerOperation(
        Summary = "Get worker by UID",
        Description = "Retrieve a specific worker by their unique identifier",
        OperationId = "GetWorkerByUid")]
    [SwaggerResponse(200, "Worker found", typeof(WorkerResource))]
    [SwaggerResponse(404, "Worker not found")]
    [SwaggerResponse(500, "Internal server error")]
    public async Task<IActionResult> GetWorkerByUid([FromRoute] Guid uid)
    {
        var getWorkerByUidQuery = new GetWorkerByUidQuery(uid);
        var worker = await workerQueryService.Handle(getWorkerByUidQuery);
        if (worker == null) return NotFound();
        var workerResource = WorkerResourceFromEntityAssembler.ToResourceFromEntity(worker);
        return Ok(workerResource);
    }

    /**
     * <summary>
     *     Get all workers
     * </summary>
     * <returns>List of worker resources</returns>
     */
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all workers",
        Description = "Retrieve a list of all workers in the system",
        OperationId = "GetAllWorkers")]
    [SwaggerResponse(200, "Workers retrieved successfully", typeof(IEnumerable<WorkerResource>))]
    [SwaggerResponse(500, "Internal server error")]
    public async Task<IActionResult> GetAllWorkers()
    {
        var workers = await workerQueryService.GetAllAsync();
        var workerResources = workers.Select(WorkerResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(workerResources);
    }
}