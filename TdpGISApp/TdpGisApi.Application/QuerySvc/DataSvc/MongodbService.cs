using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;
using TdpGisApi.Application.QuerySvc.Mapping;
using TdpGisApi.Configuration.Interface;
using TdpGisApi.Configuration.Model;
using TdpGisApi.Infrastructure.Mongodb;

namespace TdpGisApi.Application.QuerySvc.DataSvc
{
    //TODO
    //Need to refactorize this class to deal with multiple MongoDb connection
    
    public class MongodbService : IMongodbService
    {
        private readonly ILogger _logger;

        public MongodbService(ILogger<MongodbService> logger, IMongodbContext dbContext)
        {
            _logger = logger;
            DbContext = dbContext;
        }

        public IMongodbContext DbContext { get; set; }

        public IDataSourceSettings DbSettings { get; set; }

        public IMongoCollection<BsonDocument> MongodbCollection { get; private set; }

        public void Init(IDataSourceSettings dbSettings)
        {
            DbSettings = dbSettings;
            DbContext.ClearDatabase();
            DbContext.CurrentDataSourceSettings = DbSettings;
            MongodbCollection = DbContext.GetBasicCollection<BsonDocument>(DbSettings.Entity);
        }

        public List<BsonDocument> QueryText(string queriedField, string queriedText, int pageLimit, int pageSkip)
        {
            _logger.LogInformation("Query with parameters {queriedField}, {queriedText}, {pageLimit}, {pageSkip}",
                queriedField, queriedText, pageLimit, pageSkip);

            var queryExpr = new BsonRegularExpression(new Regex(queriedText, RegexOptions.IgnoreCase));

            var filterByText = Builders<BsonDocument>.Filter.Regex(queriedField, queryExpr);

            return MongodbCollection.Find(filterByText).Skip(pageSkip).Limit(pageLimit).ToList();
        }

        public List<JObject> QueryTextWithMapping(string queriedField, string queriedText, int pageLimit, int pageSkip,
            List<PropertyOutput> maps, IOutputMapping outputMapping)
        {
            var bsonList = QueryText(queriedField, queriedText, pageLimit, pageSkip);

            var jObjects = new List<JObject>();

            bsonList.ForEach(x => jObjects.Add(outputMapping.ConvertFromBson(x, maps)));

            return jObjects;
        }

        public bool CollectionExists(string collectionName)
        {
            return DbContext.CollectionExists(collectionName);
        }


        public BsonDocument GetOneDocument(string collectionName)
        {
            return DbContext.GetBasicCollection<BsonDocument>(collectionName).Find(new BsonDocument()).FirstOrDefault();
        }
    }
}