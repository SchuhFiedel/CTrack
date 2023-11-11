
namespace CTrack.Server.Contracts
{
    public interface ICTrackContext: IDisposable
    {
        void Add<TEntity>(TEntity entity) where TEntity : class;
        void Update<TEntity>(TEntity entity) where TEntity : class;
        void Remove<TEntity>(TEntity entity) where TEntity : class;
        IQueryable<TEntity> Query<TEntity>() where TEntity : class;
        TEntity? GetById<TEntity, TId>(TId id) where TEntity : class;
        int SaveChanges();
    }
}
