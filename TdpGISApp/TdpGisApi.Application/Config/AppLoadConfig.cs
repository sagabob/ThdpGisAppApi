using System;
using TdpGisApi.Configuration.Interface;
using TdpGisApi.Configuration.Model;

namespace TdpGisApi.Application.Config
{
    public class AppLoadConfig
    {
        public AppLoadConfig(IDataSourceSettings dataSourceSettings)
        {
            DbSettings = dataSourceSettings;

            InitializeConfig();
        }

        public IDataSourceSettings DbSettings { get; set; }
        public GisAppConfig AppConfigInstance { get; set; }

        private void InitializeConfig()
        {
            AppConfigInstance = new GisAppConfig();

            //TODO Extend to MsSQL
            switch (DbSettings.DatabaseType)
            {
                case SourceType.Mongodb:

                    AppConfigInstance.AddQueryConfigs(AppBuilderFromMongodb.BuildConfigApp(DbSettings));
                    break;
                case SourceType.MsSql:
                    throw new NotImplementedException("Getting Query Data Configuration from MsSQL is not implemented");
            }
        }
    }
}