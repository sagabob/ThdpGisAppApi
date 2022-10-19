using System.IO;
using Microsoft.Extensions.Configuration;
using TdpGisApi.Application.Config;

namespace TdpGisApi.Configuration.Mongodb.SeedData
{
    public class ConfigurationHelper
    {
        public static CollectionOfConnectStrings LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true);

            builder.AddUserSecrets<ConfigurationHelper>();

            var configuration = builder.Build();

            var connectStringSettings = new CollectionOfConnectStrings();
            configuration.GetSection("CollectionOfConnectStrings").Bind(connectStringSettings);

            EncrpytingConnectionString(configuration["ConnectionDbKey"], connectStringSettings);

            return connectStringSettings;
        }

        private static CollectionOfConnectStrings EncrpytingConnectionString(string key,
            CollectionOfConnectStrings connectStrings)
        {
            connectStrings.ReadOnlyConnectionString =
                SecurityUtility.EncryptString(key, connectStrings.ReadOnlyConnectionString);

            return connectStrings;
        }
    }
}