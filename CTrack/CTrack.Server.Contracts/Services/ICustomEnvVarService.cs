namespace CTrack.Server.Contracts.Services
{
    public interface ICustomEnvVarService
    {
        public string? HostAddress { get; set; }
        public string? DataBaseName { get; set; }
        public string? DataBasePassword { get; set; }
        public string? DataBaseUser { get; set; }
        public bool DataBaseReset { get; set; }
    }
}
