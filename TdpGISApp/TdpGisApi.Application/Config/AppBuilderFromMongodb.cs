using System.Collections.Generic;
using MongoDB.Driver;
using TdpGisApi.Configuration.Interface;
using TdpGisApi.Configuration.Model;
using TdpGisApi.Infrastructure.Mongodb;

namespace TdpGisApi.Application.Config
{
    public class AppBuilderFromMongodb
    {
        public static List<QueryConfig> BuildConfigApp(IDataSourceSettings dbSettings)
        {
            IMongodbContext context = new MongodbContext(dbSettings);

            return context.GetCollection<QueryConfig>(dbSettings.Entity).AsQueryable().ToList();
        }
    }
}