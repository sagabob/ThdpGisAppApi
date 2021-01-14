using MongoDB.Bson.Serialization;

namespace TdpGisApi.Configuration.Mongodb.Mapping
{
    public abstract class MongodbClassMap<T>
    {
        protected MongodbClassMap()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(T)))
            {
                BsonClassMap.RegisterClassMap<T>(Map);
            }
        }

        public abstract void Map(BsonClassMap<T> cm);
    }
}