using CTrack.Server.Contracts;
using CTrack.Server.Contracts.Services;
using CTrack.Server.Services;
using CTrackServer.DAL;

namespace CTrack.Server
{
    public static class DependencyRegistrationManager
    {
        public static void Register(IServiceCollection services)
        {
            services.AddSingleton<ICustomEnvVarService, CustomEnvVarService>();
            services.AddSingleton<ICTrackContext, CTrackContext>();
            services.AddSingleton<IPasswordHashService, PasswordHashService>();
        }
    }
}
