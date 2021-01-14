using MongoDB.Bson;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using TdpGisApi.Application.QuerySvc.Mapping;
using TdpGisApi.Configuration.Interface;
using TdpGisApi.Configuration.Model;

namespace TdpGisApi.Application.QuerySvc.DataSvc
{
    public interface IMongodbService
    {
        List<BsonDocument> QueryText(string queriedField, string queriedText, int pageLimit, int pageSkip);

        List<JObject> QueryTextWithMapping(string queriedField, string queriedText, int pageLimit, int pageSkip,
            List<PropertyOutput> maps, IOutputMapping outputMapping);

        void Init(IDataSourceSettings dbSettings);
        BsonDocument GetOneDocument(string collectionName);
        bool CollectionExists(string collectionName);
    }
}