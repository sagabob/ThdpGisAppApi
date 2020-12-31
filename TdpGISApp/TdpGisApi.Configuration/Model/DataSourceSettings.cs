using TdpGisApi.Configuration.Interface;

namespace TdpGisApi.Configuration.Model
{
    public class DataSourceSettings : IDataSourceSettings
    {
        public string ConnectionString { get; set; }

        public string Database { get; set; }

        public string Entity { get; set; }

        public SourceType DatabaseType { get; set; }
    }


    public enum SourceType
    {
        Mongodb,
        MsSql
    }
}