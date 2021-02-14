using System;
using System.Linq;
using System.Reflection;

namespace TdpGisApi.Configuration.Mongodb.Mapping
{
    public class ConfigMongodbClassMapping
    {
        public static void Mapping()
        {
            var assembly = Assembly.GetAssembly(typeof(QueryConfigMap));

            //get all types that have our MongodbClassMap as their base class
            var classMaps = assembly?
                .GetTypes()
                .Where(t => t.BaseType != null && t.BaseType.IsGenericType &&
                            t.BaseType.GetGenericTypeDefinition() == typeof(MongodbClassMap<>));

            //automate the new *ClassMap()
            if (classMaps == null) return;
            foreach (var classMap in classMaps) Activator.CreateInstance(classMap);
        }
    }
}