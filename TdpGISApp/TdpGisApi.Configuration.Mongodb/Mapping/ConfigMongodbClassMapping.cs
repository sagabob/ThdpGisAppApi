using System;
using System.Linq;
using System.Reflection;

namespace TdpGisApi.Configuration.Mongodb.Mapping
{
    public class ConfigMongodbClassMapping
    {
        public static void Mapping()
        {
            Assembly assembly = Assembly.GetAssembly(typeof(QueryConfigMap));

            //get all types that have our MongodbClassMap as their base class
            System.Collections.Generic.IEnumerable<Type> classMaps = assembly
                .GetTypes()
                .Where(t => t.BaseType != null && t.BaseType.IsGenericType &&
                            t.BaseType.GetGenericTypeDefinition() == typeof(MongodbClassMap<>));

            //automate the new *ClassMap()
            foreach (Type classMap in classMaps)
            {
                Activator.CreateInstance(classMap);
            }
        }
    }
}