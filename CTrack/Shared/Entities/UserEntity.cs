

using CTrack.Shared.Models.Models;

namespace CTrack.Shared.Models.Entities
{
    public class UserEntity: Entity
    {
        public List<UserRole> Roles = new();
        public string Email { get; set; } = "";
        public string PasswordHash { get; set; } = "";
    }
}
