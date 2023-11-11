using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTrack.Shared.Models
{
    public enum UserRole
    {
        Admin = 1,
    }

    public class UserModel: Model
    {
        public List<UserRole> Roles = new();
        Email Email { get; set; }

#region constructors
        public UserModel(Email email, IEnumerable<UserRole> roles)
        {
            Email = email;
            Id = Guid.NewGuid();
            CreatedOn = DateTime.UtcNow;
            Roles = roles.ToList();
        }

        public UserModel(Email email): this(email, new List<UserRole>())
        { }

#pragma warning disable CS8618
        /// <summary>
        /// Do not use this
        /// </summary>
        public UserModel()
        {
            // Deserialization purposes
        }
#pragma warning restore CS8618

        /// <summary>
        /// Create a User with an Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static UserModel StandardUser(Email email)
            => new(email);

        /// <summary>
        /// Create a Admin user 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static UserModel AdminUser(Email email)
            => new(email, new List<UserRole>() { UserRole.Admin });

#endregion
        public void AssignRole(UserRole role)
        {
            if (!Roles.Contains(role))
                Roles.Add(role);
        }

        // TODO: Make thread-safe
        public void RevokeRole(UserRole role)
        {
            if (Roles.Contains(role))
                Roles.Remove(role);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;

            UserModel other = (UserModel)obj;
            return Id.Equals(other.Id) &&
                   Email.Equals(other.Email) &&
                   Roles.SequenceEqual(other.Roles);
        }

        public override int GetHashCode()
            => HashCode.Combine(Id);
    }
}
