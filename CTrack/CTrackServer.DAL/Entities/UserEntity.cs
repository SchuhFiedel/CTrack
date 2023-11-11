using CTrack.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTrackServer.DAL.Entities
{
    public class UserEntity: Entity
    {
        public List<UserRole> Roles = new();
        public string Email { get; set; } = "";
        public string PasswordHash { get; set; } = "";
    }
}
