using TuChambaPe.Reviews.Domain.Model.Aggregates;
using TuChambaPe.Reviews.Interfaces.REST.Resources;

namespace TuChambaPe.Reviews.Interfaces.REST.Transform;

public static class ReviewResourceFromEntityAssembler
{
    public static ReviewResource ToResourceFromEntity(Review entity)
    {
        return new ReviewResource(entity.Uid, entity.ReceiverUserId, entity.AuthorUserId, entity.Rating, entity.Comment, entity.CreatedAt, entity.UpdatedAt);
    }
}