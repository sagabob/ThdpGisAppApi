namespace TdpGisApi.Configuration.Mongodb.SeedData
{
    public class CollectionOfConnectStrings
    {
        public string ReadOnlyConnectionString { get; set; }

        public string ReadWriteConnectionString { get; set; }

        public string Database { get; set; }

        public string Entity { get; set; }
    }
}