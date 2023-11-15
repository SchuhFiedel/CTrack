using CTrack.Server.Shared.Contracts.Repos;
using CTrack.Shared.Models.Entities;
using CTrackServer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTrack.Server.DAL.Repos
{
    public class UserRepo : IUserRepo
    {
        protected readonly CTrackContext dbContext;

        public UserRepo(ICTrackContext<Entity> dbContext)
        {
            this.dbContext = (CTrackContext)dbContext;
        }

        public Guid Add(UserEntity entity)
        {
            if (dbContext.Users.Where(x => x.Email == entity.Email || x.Id == entity.Id).Any())
                throw new ArgumentException($"User already exists!");

            var entry = dbContext.Users.Add(entity);

            SaveChanges();

            if (!entry.Entity.Id.HasValue)
                throw new ApplicationException($"Insert did not return an object ID! {nameof(entity)}");
            return entry.Entity.Id.Value;
        }

        public UserEntity? GetById(Guid id)
        {
            return dbContext.Users.Where(x => x.Id == id).FirstOrDefault();
        }

        public UserEntity? GetUserByName(string username)
        {
            return this.dbContext.Users.Where(x => x.Email == username)
                .Select(p => new UserEntity() 
                {   
                    Email = p.Email, 
                    Id = p.Id, 
                    PasswordHash = p.PasswordHash, 
                    Roles = p.Roles 
                }).FirstOrDefault();
        }

        public IQueryable Query()
        {
            return this.dbContext.Users;
        }

        public void Remove(UserEntity entity)
        {
            this.dbContext.Users.Remove(entity);
            SaveChanges();
        }

        public int SaveChanges()
        {
            return dbContext.SaveChanges();
        }

        public void Update(UserEntity entity)
        {
            this.dbContext.Update(entity);
        }
    }
}
