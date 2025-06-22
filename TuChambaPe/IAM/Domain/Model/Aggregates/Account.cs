using System.Text.Json.Serialization;

namespace TuChambaPe.IAM.Domain.Model.Aggregates
{
    public class Account(Guid uid, string email, string passwordHash)
    {
        public Account() : this(Guid.NewGuid(), string.Empty, string.Empty)
        {
        }

        public int Id { get; }
        public Guid Uid { get; } = uid;
        public string Email { get; private set; } = email;


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
    }
} 