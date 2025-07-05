using TuChambaPe.Reviews.Domain.Model.Commands;
using TuChambaPe.Reviews.Interfaces.REST.Resources;

namespace TuChambaPe.Reviews.Interfaces.REST.Transform;

public static class CreateReviewCommandFromResourceAssembler
{
    public static CreateReviewCommand ToCommandFromResource(CreateReviewResource resource)
    {
        return new CreateReviewCommand(resource.Uid, resource.ReceiverUserId, resource.AuthorUserId, resource.Rating, resource.Comment);
    }
}