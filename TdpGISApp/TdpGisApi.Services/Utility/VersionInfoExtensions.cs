using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TdpGisApi.Services.Utility
{
    public static class VersionInfoExtensions
    {
        public static IServiceCollection LoadVersionInformation(this IServiceCollection services,
            IConfiguration configuration, string configurationSectionName)
        {
            VersionInformation versionInformation = new VersionInformation();

            configuration.GetSection(configurationSectionName).Bind(versionInformation);

            VersionInformation outputVersionInformation = VersionUtility.GetVersion(versionInformation);

            services.AddSingleton(outputVersionInformation);

            return services;
        }
    }
}