using System.Text.Json.Serialization;

namespace TuChambaPe.Users.Domain.Model.Aggregates
{
    public class Worker(Guid uid, string firstName, string lastName, string phone, string profileType, string location, string bio, List<string> skills, int experience, List<string> certifications, bool isVerified = false, string? avatar = null)
    {
        public Worker() : this(Guid.NewGuid(), string.Empty, string.Empty, string.Empty, "INDIVIDUAL", string.Empty, string.Empty, new List<string>(), 0, new List<string>())
        {
        }

        public int Id { get; }
        public Guid Uid { get; } = uid;
        public string FirstName { get; private set; } = firstName;
        public string LastName { get; private set; } = lastName;
        public string Phone { get; private set; } = phone;
        public string? Avatar { get; private set; } = avatar;
        public string ProfileType { get; private set; } = profileType; // INDIVIDUAL, BUSINESS
        public string Location { get; private set; } = location;
        public string Bio { get; private set; } = bio;
        public List<string> Skills { get; private set; } = skills;
        public int Experience { get; private set; } = experience;
        public List<string> Certifications { get; private set; } = certifications;
        public double Rating { get; private set; } = 0.0;
        public int ReviewCount { get; private set; } = 0;
        public bool IsVerified { get; private set; } = isVerified;
        public Dictionary<string, string> Availability { get; private set; } = new Dictionary<string, string>
        {
            { "lunes", "" },
            { "martes", "" },
            { "miercoles", "" },
            { "jueves", "" },
            { "viernes", "" },
            { "sabado", "" },
            { "domingo", "" }
        };
        public string? YapeNumber { get; private set; }
        public string? PlinNumber { get; private set; }
        public string? BankAccountNumber { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;

        public Worker UpdateFirstName(string firstName)
        {
            FirstName = firstName;
            UpdatedAt = DateTime.UtcNow;
            return this;
        }

        public Worker UpdateLastName(string lastName)
        {
            LastName = lastName;
            UpdatedAt = DateTime.UtcNow;
            return this;
        }

        public Worker UpdatePhone(string phone)
        {
            Phone = phone;
            UpdatedAt = DateTime.UtcNow;
            return this;
        }

        public Worker UpdateAvatar(string avatar)
        {
            Avatar = avatar;
            UpdatedAt = DateTime.UtcNow;
            return this;
        }

        public Worker UpdateProfileType(string profileType)
        {
            ProfileType = profileType;
            UpdatedAt = DateTime.UtcNow;
            return this;
        }

        public Worker UpdateLocation(string location)
        {
            Location = location;
            UpdatedAt = DateTime.UtcNow;
            return this;
        }

        public Worker UpdateBio(string bio)
        {
            Bio = bio;
            UpdatedAt = DateTime.UtcNow;
            return this;
        }

        public Worker UpdateSkills(List<string> skills)
        {
            Skills = skills;
            UpdatedAt = DateTime.UtcNow;
            return this;
        }

        public Worker UpdateExperience(int experience)
        {
            Experience = experience;
            UpdatedAt = DateTime.UtcNow;
            return this;
        }

        public Worker UpdateCertifications(List<string> certifications)
        {
            Certifications = certifications;
            UpdatedAt = DateTime.UtcNow;
            return this;
        }

        public Worker UpdateRating(double rating)
        {
            Rating = rating;
            UpdatedAt = DateTime.UtcNow;
            return this;
        }

        public Worker UpdateReviewCount(int reviewCount)
        {
            ReviewCount = reviewCount;
            UpdatedAt = DateTime.UtcNow;
            return this;
        }

        public Worker SetVerificationStatus(bool isVerified)
        {
            IsVerified = isVerified;
            UpdatedAt = DateTime.UtcNow;
            return this;
        }

        public Worker UpdateAvailability(Dictionary<string, string> availability)
        {
            Availability = availability;
            UpdatedAt = DateTime.UtcNow;
            return this;
        }

        public Worker UpdatePaymentInfo(string? yapeNumber, string? plinNumber, string? bankAccountNumber)
        {
            YapeNumber = yapeNumber;
            PlinNumber = plinNumber;
            BankAccountNumber = bankAccountNumber;
            UpdatedAt = DateTime.UtcNow;
            return this;
        }
    }
}