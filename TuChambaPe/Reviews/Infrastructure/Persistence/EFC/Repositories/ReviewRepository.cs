using TuChambaPe.Reviews.Domain.Model.Aggregates;
using TuChambaPe.Reviews.Domain.Repositories;
using TuChambaPe.Shared.Infrastructure.Persistence.EFC.Configuration;
using TuChambaPe.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace TuChambaPe.Reviews.Infrastructure.Persistence.EFC.Repositories;

public class ReviewRepository(AppDbContext context) : BaseRepository<Review>(context), IReviewRepository
{
    public async Task<IEnumerable<Review>> GetByReceiverUserIdAsync(Guid receiverUserId)
    {
        return await Context.Set<Review>()
            .Where(review => review.ReceiverUserId == receiverUserId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Review>> GetByAuthorUserIdAsync(Guid authorUserId)
    {
        return await Context.Set<Review>()
            .Where(review => review.AuthorUserId == authorUserId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Review>> GetByRatingRangeAsync(int minRating, int maxRating)
    {
        return await Context.Set<Review>()
            .Where(review => review.Rating >= minRating && review.Rating <= maxRating)
            .ToListAsync();
    }
}