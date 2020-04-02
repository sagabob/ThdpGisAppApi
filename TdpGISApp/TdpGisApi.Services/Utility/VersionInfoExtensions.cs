using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TdpGisApi.Services.Utility
{
    public static class VersionInfoExtensions
    {
        public static IServiceCollection LoadVersionInformation(this IServiceCollection services,
            IConfiguration configuration, string configurationSectionName)
        {
            var versionInformation = new VersionInformation();

            configuration.GetSection(configurationSectionName).Bind(versionInformation);

            var outputVersionInformation = VersionUtility.GetVersion(versionInformation);

            services.AddSingleton(outputVersionInformation);

            return services;
        }
    }
}