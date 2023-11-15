
using CTrack.Server.DAL.Repos;
using CTrack.Server.Services;
using CTrack.Server.Shared.Contracts.Repos;
using CTrack.Server.Shared.Contracts.Services;
using CTrack.Shared.Models.Entities;
using CTrackServer.DAL;

namespace CTrack.Server
{
    public static class DependencyRegistrationManager
    {
        public static void Register(IServiceCollection services)
        {
            services.AddSingleton<ICTrackContext<Entity>, CTrackContext>();
            services.AddSingleton<IPasswordHashService, PasswordHashService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepo, UserRepo>();
        }
    }
}
