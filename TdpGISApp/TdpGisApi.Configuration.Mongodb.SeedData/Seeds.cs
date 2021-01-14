using MongoDB.Bson;
using TdpGisApi.Configuration.Interface;
using TdpGisApi.Configuration.Model;
using TdpGisApi.Infrastructure.Mongodb;

namespace TdpGisApi.Configuration.Mongodb.SeedData
{
    public class Seeds
    {
        public static void BuildConfiguration()
        {
            CollectionOfConnectStrings collectionOfConnectStrings = ConfigurationHelper.LoadConfiguration();
            IDataSourceSettings settings = new DataSourceSettings
            {
                ConnectionString =
                    collectionOfConnectStrings.ReadWriteConnectionString,
                Database = collectionOfConnectStrings.Database,
                Entity = collectionOfConnectStrings.Entity
            };

            string collectionName = collectionOfConnectStrings.Entity;

            IMongodbContext context = new MongodbContext(settings);

            MongoDB.Driver.IMongoCollection<QueryConfig> collection = context.GetCollection<QueryConfig>(collectionName);

            collection.DeleteMany(new BsonDocument()); //delete all

            collection.InsertMany(SeedData.GetConfigurationData(collectionOfConnectStrings));
        }
    }
}