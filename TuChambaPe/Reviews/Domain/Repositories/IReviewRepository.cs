using TuChambaPe.Reviews.Domain.Model.Aggregates;
using TuChambaPe.Shared.Domain.Repositories;

namespace TuChambaPe.Reviews.Domain.Repositories;

public interface IReviewRepository : IBaseRepository<Review>
{
    Task<IEnumerable<Review>> GetByReceiverUserIdAsync(Guid receiverUserId);
    Task<IEnumerable<Review>> GetByAuthorUserIdAsync(Guid authorUserId);
    Task<IEnumerable<Review>> GetByRatingRangeAsync(int minRating, int maxRating);
}