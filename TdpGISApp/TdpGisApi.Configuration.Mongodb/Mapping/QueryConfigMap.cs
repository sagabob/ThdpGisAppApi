using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using TdpGisApi.Configuration.Model;

namespace TdpGisApi.Configuration.Mongodb.Mapping
{
    public class QueryConfigMap : MongodbClassMap<QueryConfig>
    {
        public override void Map(BsonClassMap<QueryConfig> cm)
        {
            cm.AutoMap();
            //every doc has to have an id
            cm.MapIdField(x => x.Id).SetIdGenerator(StringObjectIdGenerator.Instance)
                .SetSerializer(new StringSerializer(BsonType.ObjectId));
        }
    }
}