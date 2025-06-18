using System.Text.Json.Serialization;

namespace TuChambaPe.IAM.Domain.Model.Aggregates
{
    public class User(string firstname, string passwordHash)
    {
        public User() : this(string.Empty, string.Empty)
        {
        }

        public int Id { get; }
        public string Uid { get;  }
        public string FirstName { get; private set; } = firstname;



        [JsonIgnore] public string PasswordHash { get; private set; } = passwordHash;

        /**
         * <summary>
         *     Update the username
         * </summary>
         * <param name="fullname">The new username</param>
         * <returns>The updated user</returns>
         */
        public User UpdateUsername(string fullname)
        {
            FullName = fullname;
            return this;
        }

        /**
         * <summary>
         *     Update the password hash
         * </summary>
         * <param name="passwordHash">The new password hash</param>
         * <returns>The updated user</returns>
         */
        public User UpdatePasswordHash(string passwordHash)
        {
            PasswordHash = passwordHash;
            return this;
        }
    }
}
