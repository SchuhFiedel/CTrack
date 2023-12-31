﻿using CTrack.Server.Shared;
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
            if (this.Database.CanConnect())
            {
                this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

                if (CustomEnvVarService.DataBaseReset)
                    this.Database.EnsureDeleted();

                this.Database.EnsureCreated();
            }
            else 
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

        public virtual Task<Guid> Add(Entity entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task Update(Entity entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task Remove(Entity entity)
        {
            throw new NotImplementedException();
        }

        public virtual IQueryable<Entity> Query()
        {
            throw new NotImplementedException();
        }

        public virtual Task<Entity?> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

#pragma warning disable CS0114 // Element blendet vererbtes Element aus; fehlendes Überschreibungsschlüsselwort
        public virtual Task<int> SaveChanges()
        {
            throw new NotImplementedException();
        }
#pragma warning restore CS0114 // Element blendet vererbtes Element aus; fehlendes Überschreibungsschlüsselwort
    }
}