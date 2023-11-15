using CTrack.Shared.Models.Entities;

namespace CTrack.Server.Shared.Contracts.Repos
{
    public interface IUserRepo: ICTrackContext<UserEntity>
    {
        public UserEntity? GetUserByName(string username);
    }
}
