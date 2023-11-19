using CTrack.Shared.Models.Entities;

namespace CTrack.Server.Shared.Contracts.Repos
{
    public interface IUserRepo: ICTrackContext<UserEntity>
    {
        public Task<UserEntity?> GetUserByName(string username);
    }
}
