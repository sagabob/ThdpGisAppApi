using MongoDB.Driver;
using TdpGisApi.Configuration.Interface;

namespace TdpGisApi.Infrastructure.Mongodb
{
    public interface IMongodbContext
    {
        IMongoDatabase Database { get; }
        IDataSourceSettings CurrentDataSourceSettings { get; set; }
        bool CollectionExists(string collectionName);
        IMongoCollection<TBsonDocument> GetBasicCollection<TBsonDocument>(string collectionName);
        IMongoCollection<TDocument> GetCollection<TDocument>(string collectionName);
        void ClearDatabase();
    }
}