namespace TuChambaPe.Reviews.Interfaces.REST.Resources;

public record ReviewResource(Guid Uid, Guid ReceiverUserId, Guid AuthorUserId, int Rating, string Comment, DateTime CreatedAt, DateTime UpdatedAt);