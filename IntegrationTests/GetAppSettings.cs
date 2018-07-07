
using Microsoft.Extensions.Configuration;

namespace IntegrationTests
{
    public class GetAppSettings
    {
        public readonly IConfigurationRoot Configuration;

        public GetAppSettings()
        {
            var builder = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", optional: true)
               .AddJsonFile($"appsettings.development.json");

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }
    }
}
