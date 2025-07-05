namespace TuChambaPe.Reviews.Interfaces.REST.Resources;

public record CreateReviewResource(Guid Uid, Guid ReceiverUserId, Guid AuthorUserId, int Rating, string Comment);