using TdpGisApi.Configuration.Model;

namespace TdpGisApi.Configuration.Interface
{
    public interface IDataSourceSettings
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
        public string Entity { get; set; }
        public SourceType DatabaseType { get; set; }
    }
}