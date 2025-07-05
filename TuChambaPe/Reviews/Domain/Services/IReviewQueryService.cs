using TuChambaPe.Reviews.Domain.Model.Aggregates;
using TuChambaPe.Reviews.Domain.Model.Queries;

namespace TuChambaPe.Reviews.Domain.Services;

public interface IReviewQueryService
{
    Task<Review?> Handle(GetReviewByUidQuery query);
    Task<IEnumerable<Review>> Handle(GetReviewsByReceiverUserIdQuery query);
    Task<IEnumerable<Review>> Handle(GetReviewsByAuthorUserIdQuery query);
    Task<IEnumerable<Review>> GetAllAsync();
    Task<IEnumerable<Review>> GetByReceiverUserIdAsync(Guid receiverUserId);
    Task<IEnumerable<Review>> GetByAuthorUserIdAsync(Guid authorUserId);
    Task<IEnumerable<Review>> GetByRatingRangeAsync(int minRating, int maxRating);
}