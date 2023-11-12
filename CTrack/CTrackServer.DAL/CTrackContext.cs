using CTrack.Server.Contracts;
using CTrack.Server.Contracts.Services;
using CTrackServer.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CTrackServer.DAL
{
    public class CTrackContext : DbContext, ICTrackContext
    {
        protected ICustomEnvVarService envVarService; 

        public DbSet<UserEntity> Users { get; set; }

        public CTrackContext(ICustomEnvVarService envVarService)
        {
            this.envVarService = envVarService;

            if (this.envVarService.DataBaseReset)
                this.Database.EnsureDeleted();

            this.Database.EnsureCreated();

            bool canConnect = this.Database.CanConnect();
            Console.WriteLine("Can Connect To DB: " + canConnect);
            if (!canConnect)
            {
                throw new ArgumentException(this.Database.GetConnectionString(), "ConnectionString");
            }
            Console.WriteLine("DB Provider name:" + this.Database.ProviderName);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                $"host={this.envVarService.HostAddress};" +
                $"Database={this.envVarService.DataBaseName};" +
                $"Password={this.envVarService.DataBasePassword};"+
                $"Username={this.envVarService.DataBaseUser}");
        }

        void ICTrackContext.Add<TEntity>(TEntity entity)
        {
            Add(entity);
        }

        void ICTrackContext.Update<TEntity>(TEntity entity)
        {
            Update(entity);
        }

        void ICTrackContext.Remove<TEntity>(TEntity entity)
        {
            Remove(entity);
        }

        public IQueryable<TEntity> Query<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }

        public TEntity? GetById<TEntity, TId>(TId id) where TEntity : class
        {
            var entity = Set<TEntity>().Find(id);
            return entity;
        }
    }
}