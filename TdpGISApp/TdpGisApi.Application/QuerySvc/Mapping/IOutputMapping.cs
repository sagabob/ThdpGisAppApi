using System.Collections.Generic;
using MongoDB.Bson;
using Newtonsoft.Json.Linq;
using TdpGisApi.Configuration.Model;

namespace TdpGisApi.Application.QuerySvc.Mapping
{
    public interface IOutputMapping
    {
        List<JObject> MappingQueryResult(List<BsonDocument> queryResult, List<PropertyOutput> maps);

        JObject ConvertFromBson(BsonDocument doc, List<PropertyOutput> maps);
    }
}