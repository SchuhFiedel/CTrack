

namespace CTrack.Server.Shared
{
    public static class EnvVarNamesConstants
    {
        public const string HostAddress = "CUSTOMEV_DBHOSTADDRESS";
        public const string DataBaseName = "CUSTOMEV_DBNAME";
        public const string DataBasePassword = "CUSTOMEV_DBPW";
        public const string DataBaseUser = "CUSTOMEV_DBUSER";
        public const string DataBaseReset = "CUSTOMEV_DBRESET";
        public const string JWTSecretKey = "CUSTOMEV_JWTSECRET";
    }

    public static class CustomEnvVarService 
    {
        private static string? _hostAddress;

        public static string HostAddress
        {
            get {
                _hostAddress = Environment.GetEnvironmentVariable(EnvVarNamesConstants.HostAddress);
                if (string.IsNullOrEmpty(_hostAddress))
                    throw new ArgumentNullException(nameof(EnvVarNamesConstants.HostAddress));

                return _hostAddress;
            }
        }

        private static string? _dataBaseName;
        public static string DataBaseName
        {
            get
            {
                _dataBaseName = Environment.GetEnvironmentVariable(EnvVarNamesConstants.DataBaseName);
                if (string.IsNullOrEmpty(_hostAddress))
                    throw new ArgumentNullException(nameof(EnvVarNamesConstants.DataBaseName));

                return _dataBaseName;
            }
        }

        private static string? _dataBasePassword;
        public static string DataBasePassword
        {
            get
            {
                _dataBasePassword = Environment.GetEnvironmentVariable(EnvVarNamesConstants.DataBasePassword);
                if (string.IsNullOrEmpty(_dataBasePassword))
                    throw new ArgumentNullException(nameof(EnvVarNamesConstants.DataBasePassword));

                return _dataBasePassword;
            }
        }

        public static string? _dataBaseUser;
        public static string DataBaseUser
        {
            get
            {
                _dataBaseUser = Environment.GetEnvironmentVariable(EnvVarNamesConstants.DataBaseUser);
                if (string.IsNullOrEmpty(_dataBaseUser))
                    throw new ArgumentNullException(nameof(EnvVarNamesConstants.DataBaseUser));

                return _dataBaseUser;
            }
        }

        public static bool _dataBaseReset = false;
        public static bool DataBaseReset {
            get
            {
                bool.TryParse(Environment.GetEnvironmentVariable(EnvVarNamesConstants.DataBaseReset), out bool reset);
                _dataBaseReset = reset;
                return _dataBaseReset;
            } 
        }

        public static string? _jWTSecretKey;
        public static string JWTSecretKey { 
            get 
            {
                _jWTSecretKey = Environment.GetEnvironmentVariable(EnvVarNamesConstants.JWTSecretKey);
                if (string.IsNullOrEmpty(_jWTSecretKey))
                    throw new ArgumentNullException(nameof(EnvVarNamesConstants.JWTSecretKey));
                return _jWTSecretKey;
            } 
        }
    }
}