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

            var listOfQueryConfigs = context.GetCollection<QueryConfig>(dbSettings.Entity).AsQueryable().ToList();

            return listOfQueryConfigs;
        }

        public static List<QueryConfig> DecryptConnectionStrings(List<QueryConfig> listQueryConfigs, string key)
        {
            listQueryConfigs.ForEach(x =>
                x.DbSettings.ConnectionString = SecurityUtility.DecryptString(key, x.DbSettings.ConnectionString));

            return listQueryConfigs;
        }
    }
}