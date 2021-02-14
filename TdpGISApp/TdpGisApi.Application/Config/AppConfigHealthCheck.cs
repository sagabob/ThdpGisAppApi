using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using TdpGisApi.Configuration.Model;

namespace TdpGisApi.Application.Config
{
    public class AppConfigHealthCheck : IHealthCheck
    {
        public AppConfigHealthCheck(IQueryConfigureValidator searchConfigureValidator, GisAppConfig appConfigInstance)
        {
            SearchConfigureValidator = searchConfigureValidator;
            AppConfigInstance = appConfigInstance;
        }

        public GisAppConfig AppConfigInstance { get; }
        public IQueryConfigureValidator SearchConfigureValidator { get; }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
            CancellationToken cancellationToken = default)
        {
            var result = SearchConfigureValidator.ValidateAllQueryConfiguration(AppConfigInstance);

            if (result.Status) return Task.FromResult(HealthCheckResult.Healthy());

            return Task.FromResult(new HealthCheckResult(context.Registration.FailureStatus,
                exception: result.OutputException));
        }
    }
}