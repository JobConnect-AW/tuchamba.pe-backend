using TuChambaPe.Reviews.Domain.Model.Aggregates;
using TuChambaPe.Reviews.Domain.Model.Commands;

namespace TuChambaPe.Reviews.Domain.Services;

public interface IReviewCommandService
{
    Task<Review> Handle(CreateReviewCommand command);
}