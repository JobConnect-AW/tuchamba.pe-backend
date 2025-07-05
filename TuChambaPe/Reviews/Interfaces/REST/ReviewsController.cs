using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TuChambaPe.Reviews.Domain.Model.Queries;
using TuChambaPe.Reviews.Domain.Services;
using TuChambaPe.Reviews.Interfaces.REST.Resources;
using TuChambaPe.Reviews.Interfaces.REST.Transform;

namespace TuChambaPe.Reviews.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Reviews Endpoints")]
public class ReviewsController(IReviewCommandService reviewCommandService, IReviewQueryService reviewQueryService) : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new review",
        Description = "Create a new review with the provided information",
        OperationId = "CreateReview")]
    [SwaggerResponse(201, "The review was created", typeof(ReviewResource))]
    [SwaggerResponse(400, "The review data is invalid")]
    public async Task<IActionResult> CreateReview([FromBody] CreateReviewResource resource)
    {
        var createReviewCommand = CreateReviewCommandFromResourceAssembler.ToCommandFromResource(resource);
        var review = await reviewCommandService.Handle(createReviewCommand);
        var reviewResource = ReviewResourceFromEntityAssembler.ToResourceFromEntity(review);
        return CreatedAtAction(nameof(GetReviewByUid), new { uid = reviewResource.Uid }, reviewResource);
    }

    [HttpGet("{uid:guid}")]
    [SwaggerOperation(
        Summary = "Get review by UID",
        Description = "Get review information by its unique identifier",
        OperationId = "GetReviewByUid")]
    [SwaggerResponse(200, "The review information", typeof(ReviewResource))]
    [SwaggerResponse(404, "The review was not found")]
    public async Task<IActionResult> GetReviewByUid(Guid uid)
    {
        var getReviewByUidQuery = new GetReviewByUidQuery(uid);
        var review = await reviewQueryService.Handle(getReviewByUidQuery);
        if (review == null) return NotFound();
        var reviewResource = ReviewResourceFromEntityAssembler.ToResourceFromEntity(review);
        return Ok(reviewResource);
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all reviews",
        Description = "Get all reviews in the system",
        OperationId = "GetAllReviews")]
    [SwaggerResponse(200, "The reviews information", typeof(IEnumerable<ReviewResource>))]
    public async Task<IActionResult> GetAllReviews()
    {
        var reviews = await reviewQueryService.GetAllAsync();
        var reviewResources = reviews.Select(ReviewResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(reviewResources);
    }

    [HttpGet("receiver/{receiverUserId:guid}")]
    [SwaggerOperation(
        Summary = "Get reviews by receiver user ID",
        Description = "Get all reviews for a specific receiver user",
        OperationId = "GetReviewsByReceiverUserId")]
    [SwaggerResponse(200, "The reviews information", typeof(IEnumerable<ReviewResource>))]
    public async Task<IActionResult> GetReviewsByReceiverUserId(Guid receiverUserId)
    {
        var reviews = await reviewQueryService.GetByReceiverUserIdAsync(receiverUserId);
        var reviewResources = reviews.Select(ReviewResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(reviewResources);
    }

    [HttpGet("author/{authorUserId:guid}")]
    [SwaggerOperation(
        Summary = "Get reviews by author user ID",
        Description = "Get all reviews written by a specific author",
        OperationId = "GetReviewsByAuthorUserId")]
    [SwaggerResponse(200, "The reviews information", typeof(IEnumerable<ReviewResource>))]
    public async Task<IActionResult> GetReviewsByAuthorUserId(Guid authorUserId)
    {
        var reviews = await reviewQueryService.GetByAuthorUserIdAsync(authorUserId);
        var reviewResources = reviews.Select(ReviewResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(reviewResources);
    }

    [HttpGet("rating/{minRating:int}/{maxRating:int}")]
    [SwaggerOperation(
        Summary = "Get reviews by rating range",
        Description = "Get all reviews within a specific rating range",
        OperationId = "GetReviewsByRatingRange")]
    [SwaggerResponse(200, "The reviews information", typeof(IEnumerable<ReviewResource>))]
    public async Task<IActionResult> GetReviewsByRatingRange(int minRating, int maxRating)
    {
        var reviews = await reviewQueryService.GetByRatingRangeAsync(minRating, maxRating);
        var reviewResources = reviews.Select(ReviewResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(reviewResources);
    }
}