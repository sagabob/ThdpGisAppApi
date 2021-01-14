using MongoDB.Driver;
using System.Collections.Generic;
using TdpGisApi.Configuration.Interface;
using TdpGisApi.Configuration.Model;
using TdpGisApi.Infrastructure.Mongodb;

namespace TdpGisApi.Application.Config
{
    public class AppBuilderFromMongodb
    {
        public static List<QueryConfig> BuildConfigApp(IDataSourceSettings dbSettings, string key)
        {
            IMongodbContext context = new MongodbContext(dbSettings);

            List<QueryConfig> listOfQueryConfigs = context.GetCollection<QueryConfig>(dbSettings.Entity).AsQueryable().ToList();

            return DecryptConnectionStrings(listOfQueryConfigs, key);
        }

        public static List<QueryConfig> DecryptConnectionStrings(List<QueryConfig> listQueryConfigs, string key)
        {
            listQueryConfigs.ForEach(x =>
                x.DbSettings.ConnectionString = SecurityUtility.DecryptString(key, x.DbSettings.ConnectionString));

            return listQueryConfigs;
        }
    }
}