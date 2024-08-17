using Microsoft.Extensions.Configuration;

namespace BookingRoom.Core.Configuration
{
    public class ConfigurationSetup
    {
        private const string AppSettingsFileName = "appsettings";
        private readonly string _configDirectory;
        private readonly IConfiguration _configuration;

        public ConfigurationSetup()
        {
            _configDirectory = AppContext.BaseDirectory;
            _configuration = LoadAppConfiguration();
        }


        private IConfiguration LoadAppConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(_configDirectory)
                .AddJsonFile($"{AppSettingsFileName}.json")
                .AddEnvironmentVariables()
                .AddUserSecrets<ConfigurationSetup>()
                .Build();
        }

        public AppSettingsEntity? GetAppSettings()
        {
            return _configuration.GetSection(AppSettingsFileName).Get<AppSettingsEntity>();
        }
    }
}
