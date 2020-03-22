using System.Reflection;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TdpGisApi.Application.Config;
using TdpGisApi.Application.QuerySvc.DataSvc;
using TdpGisApi.Application.QuerySvc.Factory;
using TdpGisApi.Application.QuerySvc.Handler;
using TdpGisApi.Application.QuerySvc.Mapping;
using TdpGisApi.Configuration.Interface;
using TdpGisApi.Configuration.Model;
using TdpGisApi.Configuration.Mongodb.Mapping;
using TdpGisApi.Infrastructure.Mongodb;

namespace TdpGisApi.Application.Extensions
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddMediaRExtension(this IServiceCollection services)
        {
            services.AddSingleton<QueryRegister>();
            services.AddMediatR(typeof(QueryHandler).GetTypeInfo().Assembly);
            return services;
        }

        public static IServiceCollection LoadApplicationConfiguration(this IServiceCollection services,
            IConfiguration configuration, string configurationSectionName)
        {
            var dataSourceSettings = new DataSourceSettings();

            configuration.GetSection(configurationSectionName).Bind(dataSourceSettings);

            switch (dataSourceSettings.DatabaseType)
            {
                //Mapping the Config data to fit Mongodb
                case SourceType.Mongodb:
                    ConfigMongodbClassMapping.Mapping();
                    break;
            }

            services.AddSingleton(sp =>
                new AppLoadConfig(dataSourceSettings).AppConfigInstance);

            services.AddSingleton<IDataSourceSettings>(dataSourceSettings);
            
            return services;
        }

        public static IServiceCollection AddAppConfigHealthCheck(this IServiceCollection services,
            string healthCheckName)
        {
            services.AddHealthChecks()
                .AddCheck<AppConfigHealthCheck>(healthCheckName);
            return services;
        }

        public static IServiceCollection AddFeatureDataServices(this IServiceCollection services)
        {
            services.AddTransient<IMongodbContext, MongodbContext>();
            services.AddTransient<IMongodbService, MongodbService>();
            services.AddTransient<IQueryConfigureValidator, QueryConfigurationMongodbValidator>();
            services.AddTransient<IOutputMapping, OutputMapping>();
            return services;
        }
    }
}