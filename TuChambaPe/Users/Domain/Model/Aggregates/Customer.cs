using System.Text.Json.Serialization;

namespace TuChambaPe.Users.Domain.Model.Aggregates
{
    public class Customer(Guid uid, string firstName, string lastName, string phone, string profileType, string location, string bio, bool isVerified = false)
    {
        public Customer() : this(Guid.NewGuid(), string.Empty, string.Empty, string.Empty, "INDIVIDUAL", string.Empty, string.Empty)
        {
        }

        public int Id { get; }
        public Guid Uid { get; } = uid;
        public string FirstName { get; private set; } = firstName;
        public string LastName { get; private set; } = lastName;
        public string Phone { get; private set; } = phone;
        public string ProfileType { get; private set; } = profileType; // INDIVIDUAL, BUSINESS
        public string Location { get; private set; } = location;
        public string Bio { get; private set; } = bio;
        public bool IsVerified { get; private set; } = isVerified;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;

        public Customer UpdateFirstName(string firstName)
        {
            FirstName = firstName;
            UpdatedAt = DateTime.UtcNow;
            return this;
        }


        public Customer UpdateLastName(string lastName)
        {
            LastName = lastName;
            UpdatedAt = DateTime.UtcNow;
            return this;
        }

        public Customer UpdatePhone(string phone)
        {
            Phone = phone;
            UpdatedAt = DateTime.UtcNow;
            return this;
        }

        public Customer UpdateProfileType(string profileType)
        {
            ProfileType = profileType;
            UpdatedAt = DateTime.UtcNow;
            return this;
        }

        public Customer UpdateLocation(string location)
        {
            Location = location;
            UpdatedAt = DateTime.UtcNow;
            return this;
        }

        public Customer UpdateBio(string bio)
        {
            Bio = bio;
            UpdatedAt = DateTime.UtcNow;
            return this;
        }

        public Customer SetVerificationStatus(bool isVerified)
        {
            IsVerified = isVerified;
            UpdatedAt = DateTime.UtcNow;
            return this;
        }
    }
}