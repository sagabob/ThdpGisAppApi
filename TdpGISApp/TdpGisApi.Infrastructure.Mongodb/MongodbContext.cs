using System;
using MongoDB.Bson;
using MongoDB.Driver;
using TdpGisApi.Configuration.Interface;

namespace TdpGisApi.Infrastructure.Mongodb
{
    public class MongodbContext : IMongodbContext
    {
        private IMongoClient _client;
        private IMongoDatabase _database;

        public MongodbContext()
        {
        }

        public MongodbContext(IDataSourceSettings settings)
        {
            CurrentDataSourceSettings = settings;
            Init();
        }

        public IDataSourceSettings CurrentDataSourceSettings { get; set; }

        public IMongoDatabase Database
        {
            get
            {
                if (_database == null)
                {
                    if (CurrentDataSourceSettings == null)
                        throw new ArgumentException("No valid data connection configuration");

                    Init();
                }

                return _database;
            }
        }

        public void ClearDatabase()
        {
            _database = null;
        }

        public bool CollectionExists(string collectionName)
        {
            var filter = new BsonDocument("name", collectionName);
            var options = new ListCollectionNamesOptions {Filter = filter};

            return Database.ListCollectionNames(options).Any();
        }

        public IMongoCollection<TDocument> GetCollection<TDocument>(string collectionName)
        {
            if (CollectionExists(collectionName))
                return Database.GetCollection<TDocument>(collectionName);

            return null; //possible throw exception
        }


        public IMongoCollection<BsonDocument> GetBasicCollection<BsonDocument>(string collectionName)
        {
            if (CollectionExists(collectionName))
                return Database.GetCollection<BsonDocument>(collectionName);

            throw new ArgumentException($"Input collection name {collectionName} doesn't exist in database");
        }

        public void Init()
        {
            var mongdbSettings = MongoClientSettings.FromUrl(new MongoUrl(CurrentDataSourceSettings.ConnectionString));
            _client = new MongoClient(mongdbSettings);
            _database = _client.GetDatabase(CurrentDataSourceSettings.Database);
        }
    }
}