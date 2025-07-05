using TuChambaPe.Reviews.Domain.Model.Aggregates;
using TuChambaPe.Reviews.Domain.Model.Commands;
using TuChambaPe.Reviews.Domain.Repositories;
using TuChambaPe.Reviews.Domain.Services;
using TuChambaPe.Shared.Domain.Repositories;

namespace TuChambaPe.Reviews.Application.Internal.CommandServices;

public class ReviewCommandService(IReviewRepository reviewRepository, IUnitOfWork unitOfWork) : IReviewCommandService
{
    public async Task<Review> Handle(CreateReviewCommand command)
    {
        var review = new Review(command.Uid, command.ReceiverUserId, command.AuthorUserId, 
            command.Rating, command.Comment);
        
        await reviewRepository.AddAsync(review);
        await unitOfWork.CompleteAsync();
        return review;
    }
}