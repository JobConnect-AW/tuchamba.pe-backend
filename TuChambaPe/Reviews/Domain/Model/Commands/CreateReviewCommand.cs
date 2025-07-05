namespace TuChambaPe.Reviews.Domain.Model.Commands;

public record CreateReviewCommand(Guid Uid, Guid ReceiverUserId, Guid AuthorUserId, int Rating, string Comment);