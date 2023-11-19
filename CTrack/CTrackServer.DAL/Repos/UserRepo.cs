using CTrack.Server.Shared.Contracts.Repos;
using CTrack.Shared.Models.Entities;
using CTrackServer.DAL;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Guid> Add(UserEntity entity)
        {
            if (dbContext.Users.Where(x => x.Email == entity.Email || x.Id == entity.Id).Any())
                throw new ArgumentException($"User already exists!");

            var entry = await dbContext.Users.AddAsync(entity);

            await SaveChanges();

            if (!entry.Entity.Id.HasValue)
                throw new ApplicationException($"Insert did not return an object ID! {nameof(entity)}");
            return entry.Entity.Id.Value;
        }

        public async Task<UserEntity?> GetById(Guid id)
        {
            return await dbContext.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<UserEntity?> GetUserByName(string username)
        {
            return await this.dbContext.Users.Where(x => x.Email == username)
                .Select(p => new UserEntity() 
                {   
                    Email = p.Email, 
                    Id = p.Id, 
                    PasswordHash = p.PasswordHash, 
                    Roles = p.Roles 
                }).FirstOrDefaultAsync();
        }

        public IQueryable<UserEntity> Query()
        {
            return this.dbContext.Users;
        }

        public async Task Remove(UserEntity entity) 
        { 
            this.dbContext.Users.Remove(entity);
            await SaveChanges();
        }

        public async Task Update(UserEntity entity)
        {
            this.dbContext.Users.Update(entity);
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await dbContext.SaveChangesAsync();
        }
    }
}
