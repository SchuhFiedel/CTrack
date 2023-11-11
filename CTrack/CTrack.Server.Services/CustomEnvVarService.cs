using CTrack.Server.Contracts.Services;

namespace CTrack.Server.Services
{
    public static class EnvVarNamesConstants
    {
        public const string HostAddress = "CUSTOMEV_DBHOSTADDRESS";
        public const string DataBaseName = "CUSTOMEV_DBNAME";
        public const string DataBasePassword = "CUSTOMEV_DBPW";
        public const string DataBaseUser = "CUSTOMEV_DBUSER";
        public const string DataBaseReset = "CUSTOMEV_DBRESET";
    }

    public class CustomEnvVarService : ICustomEnvVarService
    {
        public string? HostAddress { get; set; } = null;
        public string? DataBaseName { get; set; } = null;
        public string? DataBasePassword { get; set; } = null;
        public string? DataBaseUser { get; set; } = null;
        public bool DataBaseReset { get; set; } = false;

        public CustomEnvVarService()
        {
            //Check if all needed Env Vars are set

            this.HostAddress = Environment.GetEnvironmentVariable(EnvVarNamesConstants.HostAddress);
            if (string.IsNullOrEmpty(this.HostAddress))
                throw new ArgumentNullException(nameof(EnvVarNamesConstants.HostAddress));

            this.DataBaseName = Environment.GetEnvironmentVariable(EnvVarNamesConstants.DataBaseName);
            if (string.IsNullOrEmpty(this.DataBaseName))
                throw new ArgumentNullException(nameof(EnvVarNamesConstants.DataBaseName));

            this.DataBasePassword = Environment.GetEnvironmentVariable(EnvVarNamesConstants.DataBasePassword);
            if (string.IsNullOrEmpty(this.DataBasePassword))
                throw new ArgumentNullException(nameof(EnvVarNamesConstants.DataBasePassword));

            this.DataBaseUser = Environment.GetEnvironmentVariable(EnvVarNamesConstants.DataBaseUser);
            if (string.IsNullOrEmpty(this.DataBaseUser))
                throw new ArgumentNullException(nameof(EnvVarNamesConstants.DataBaseUser));

            this.DataBaseUser = Environment.GetEnvironmentVariable(EnvVarNamesConstants.DataBaseUser);
            if (string.IsNullOrEmpty(this.DataBaseUser))
                throw new ArgumentNullException(nameof(EnvVarNamesConstants.DataBaseUser));

            bool.TryParse(Environment.GetEnvironmentVariable(EnvVarNamesConstants.DataBaseReset), out bool reset);
            this.DataBaseReset = reset;
        }
    }
}