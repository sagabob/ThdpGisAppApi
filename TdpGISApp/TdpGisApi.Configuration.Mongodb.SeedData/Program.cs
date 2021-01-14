using System;
using TdpGisApi.Configuration.Mongodb.Mapping;

namespace TdpGisApi.Configuration.Mongodb.SeedData
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Seeding configuration data!");

            //mapping mongo
            ConfigMongodbClassMapping.Mapping();

            Seeds.BuildConfiguration();
        }
    }
}