using System.Text.Json.Serialization;
using TuChambaPe.IAM.Domain.Model;

namespace TuChambaPe.IAM.Domain.Model.Aggregates
{
    public class Account(Guid uid, string email, string passwordHash, string role)
    {
        public Account() : this(Guid.NewGuid(), string.Empty, string.Empty, ValueObjects.Role.CUSTOMER)
        {
        }

        public int Id { get; }
        public Guid Uid { get; } = uid;
        public string Email { get; private set; } = email;
        public string Role { get; private set; } = role;

        [JsonIgnore] public string PasswordHash { get; private set; } = passwordHash;


        /**
         * <summary>
         *     Update email
         * </summary>
         * <param name="email">The new email</param>
         * <returns>The updated account</returns>
        */
        public Account UpdateEmail(string email)
        {
            Email = email;
            return this;
        }


        /**
         * <summary>
         *     Update the password hash
         * </summary>
         * <param name="passwordHash">The new password hash</param>
         * <returns>The updated account</returns>
         */
        public Account UpdatePasswordHash(string passwordHash)
        {
            PasswordHash = passwordHash;
            return this;
        }

        /**
         * <summary>
         *     Update the role
         * </summary>
         * <param name="role">The new role</param>
         * <returns>The updated account</returns>
         */
        public Account UpdateRole(string role)
        {
            if (!TuChambaPe.IAM.Domain.Model.ValueObjects.Role.IsValid(role))
                throw new ArgumentException("Invalid role", nameof(role));
            
            Role = role;
            return this;
        }
    }
} 