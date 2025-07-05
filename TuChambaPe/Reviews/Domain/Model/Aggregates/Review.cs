using System.Text.Json.Serialization;

namespace TuChambaPe.Reviews.Domain.Model.Aggregates
{
    public class Review(Guid uid, Guid receiverUserId, Guid authorUserId, int rating, string comment)
    {
        public Review() : this(Guid.NewGuid(), Guid.Empty, Guid.Empty, 0, string.Empty)
        {
        }

        public int Id { get; }
        public Guid Uid { get; } = uid;
        public Guid ReceiverUserId { get; private set; } = receiverUserId;
        public Guid AuthorUserId { get; private set; } = authorUserId;
        public int Rating { get; private set; } = rating;
        public string Comment { get; private set; } = comment;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;

        public Review UpdateRating(int rating)
        {
            Rating = rating;
            UpdatedAt = DateTime.UtcNow;
            return this;
        }

        public Review UpdateComment(string comment)
        {
            Comment = comment;
            UpdatedAt = DateTime.UtcNow;
            return this;
        }
    }
}