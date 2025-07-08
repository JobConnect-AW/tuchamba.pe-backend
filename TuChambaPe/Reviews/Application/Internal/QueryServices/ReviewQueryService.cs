using TuChambaPe.Reviews.Domain.Model.Aggregates;
using TuChambaPe.Reviews.Domain.Model.Queries;
using TuChambaPe.Reviews.Domain.Repositories;
using TuChambaPe.Reviews.Domain.Services;

namespace TuChambaPe.Reviews.Application.Internal.QueryServices;

/**
 * <summary>
 *     The review query service
 * </summary>
 * <remarks>
 *     This service is used to handle review queries
 * </remarks>
 */

public class ReviewQueryService(IReviewRepository reviewRepository) : IReviewQueryService
{
    public async Task<Review?> Handle(GetReviewByUidQuery query)
    {
        return await reviewRepository.FindByUidAsync(query.Uid);
    }

    public async Task<IEnumerable<Review>> Handle(GetReviewsByReceiverUserIdQuery query)
    {
        return await reviewRepository.GetByReceiverUserIdAsync(query.ReceiverUserId);
    }

    public async Task<IEnumerable<Review>> Handle(GetReviewsByAuthorUserIdQuery query)
    {
        return await reviewRepository.GetByAuthorUserIdAsync(query.AuthorUserId);
    }

    public async Task<IEnumerable<Review>> GetAllAsync()
    {
        return await reviewRepository.ListAsync();
    }

    public async Task<IEnumerable<Review>> GetByReceiverUserIdAsync(Guid receiverUserId)
    {
        return await reviewRepository.GetByReceiverUserIdAsync(receiverUserId);
    }

    public async Task<IEnumerable<Review>> GetByAuthorUserIdAsync(Guid authorUserId)
    {
        return await reviewRepository.GetByAuthorUserIdAsync(authorUserId);
    }

    public async Task<IEnumerable<Review>> GetByRatingRangeAsync(int minRating, int maxRating)
    {
        return await reviewRepository.GetByRatingRangeAsync(minRating, maxRating);
    }
}