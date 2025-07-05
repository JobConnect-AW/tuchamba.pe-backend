using System.Text.Json.Serialization;

namespace TuChambaPe.Users.Domain.Model.Aggregates
{
    public class User(Guid uid, Guid accountId, Guid? customerId = null, Guid? workerId = null)
    {
        public User() : this(Guid.NewGuid(), Guid.NewGuid())
        {
        }

        public int Id { get; }
        public Guid Uid { get; } = uid;
        public Guid AccountId { get; private set; } = accountId;
        public Guid? CustomerId { get; private set; } = customerId;
        public Guid? WorkerId { get; private set; } = workerId;

        public User UpdateCustomerId(Guid customerId)
        {
            CustomerId = customerId;
            return this;
        }

        public User UpdateWorkerId(Guid workerId)
        {
            WorkerId = workerId;
            return this;
        }

        public User ClearCustomerId()
        {
            CustomerId = null;
            return this;
        }

        public User ClearWorkerId()
        {
            WorkerId = null;
            return this;
        }
    }
}