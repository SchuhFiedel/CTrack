namespace CTrack.Server.Shared.Contracts.Repos
{
    public interface ICTrackContext<TEntity>
    {
        Guid Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        IQueryable Query();
        TEntity? GetById(Guid id);
        int SaveChanges();
    }
}
