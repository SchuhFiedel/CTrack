using CTrack.Server.Shared;
using CTrack.Server.Shared.Contracts.Repos;
using CTrack.Server.Shared.Contracts.Services;
using CTrack.Shared.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Npgsql.Replication.PgOutput;

namespace CTrackServer.DAL
{
    public class CTrackContext : DbContext, ICTrackContext<Entity>
    {
        public DbSet<UserEntity> Users { get; set; }

        public CTrackContext()
        {

            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            if (CustomEnvVarService.DataBaseReset)
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
                $"host={CustomEnvVarService.HostAddress};" +
                $"Database={CustomEnvVarService.DataBaseName};" +
                $"Password={CustomEnvVarService.DataBasePassword};" +
                $"Username={CustomEnvVarService.DataBaseUser}");
        }

        public virtual Guid Add(Entity entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Update(Entity entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Remove(Entity entity)
        {
            throw new NotImplementedException();
        }

        public virtual IQueryable Query()
        {
            throw new NotImplementedException();
        }

        public virtual Entity? GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}