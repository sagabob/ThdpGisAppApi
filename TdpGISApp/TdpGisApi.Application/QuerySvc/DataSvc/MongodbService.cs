using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TdpGisApi.Application.QuerySvc.Mapping;
using TdpGisApi.Configuration.Interface;
using TdpGisApi.Configuration.Model;
using TdpGisApi.Infrastructure.Mongodb;

namespace TdpGisApi.Application.QuerySvc.DataSvc
{
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
            DbContext.CurrentDataSourceSettings = DbSettings;
            DbContext.ClearDatabase();
            MongodbCollection = DbContext.GetBasicCollection<BsonDocument>(DbSettings.Entity);
        }

        public List<BsonDocument> QueryText(string queriedField, string queriedText, int pageLimit, int pageSkip)
        {
            _logger.LogInformation("Query with parameters {queriedField}, {queriedText}, {pageLimit}, {pageSkip}",
                queriedField, queriedText, pageLimit, pageSkip);

            BsonRegularExpression queryExpr = new BsonRegularExpression(new Regex(queriedText, RegexOptions.IgnoreCase));

            FilterDefinition<BsonDocument> filterByText = Builders<BsonDocument>.Filter.Regex(queriedField, queryExpr);

            return MongodbCollection.Find(filterByText).Skip(pageSkip).Limit(pageLimit).ToList();
        }

        public List<JObject> QueryTextWithMapping(string queriedField, string queriedText, int pageLimit, int pageSkip,
            List<PropertyOutput> maps, IOutputMapping outputMapping)
        {
            List<BsonDocument> bsonList = QueryText(queriedField, queriedText, pageLimit, pageSkip);

            List<JObject> jObjects = new List<JObject>();

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