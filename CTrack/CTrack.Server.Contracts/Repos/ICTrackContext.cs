namespace CTrack.Server.Shared.Contracts.Repos
{
    public interface ICTrackContext<TEntity>
    {
        Task<Guid> Add(TEntity entity);
        Task Update(TEntity entity);
        Task Remove(TEntity entity);
        IQueryable<TEntity> Query();
        Task<TEntity?> GetById(Guid id);
        Task<int> SaveChanges();
    }
}
