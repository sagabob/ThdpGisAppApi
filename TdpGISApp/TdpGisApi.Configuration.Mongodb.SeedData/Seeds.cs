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
            var collectionOfConnectStrings = ConfigurationHelper.LoadConfiguration();
            IDataSourceSettings settings = new DataSourceSettings
            {
                ConnectionString =
                    collectionOfConnectStrings.ReadWriteConnectionString,
                Database = collectionOfConnectStrings.Database,
                Entity = collectionOfConnectStrings.Entity
            };

            var collectionName = collectionOfConnectStrings.Entity;

            IMongodbContext context = new MongodbContext(settings);

            var collection = context.GetCollection<QueryConfig>(collectionName);

            collection.DeleteMany(new BsonDocument()); //delete all

            collection.InsertMany(SeedData.GetConfigurationData(collectionOfConnectStrings));
        }


    }
}