using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using Newtonsoft.Json.Linq;
using TdpGisApi.Configuration.Model;

namespace TdpGisApi.Application.QuerySvc.Mapping
{
    public class OutputMapping : IOutputMapping
    {
        private readonly ILogger _logger;

        public OutputMapping(ILogger<OutputMapping> logger)
        {
            _logger = logger;
        }

        public List<JObject> MappingQueryResult(List<BsonDocument> queryResult, List<PropertyOutput> maps)
        {
            var jObjects = new List<JObject>();
            queryResult.ForEach(x => { jObjects.Add(ConvertFromBson(x, maps)); });

            return jObjects;
        }

        public JObject ConvertFromBson(BsonDocument doc, List<PropertyOutput> maps)
        {
            var jo = new JObject();
            try
            {
                foreach (var prop in maps)
                    switch (prop.ColumnType)
                    {
                        case PropertyType.Normal:
                            jo.Add(prop.OutputName, doc.GetValue(prop.PropertyName).ToString());
                            break;

                        case PropertyType.Object:
                            //work around the problem due to JObject parse BsonDocument ToJson function
                            var currentElement = JObject.Parse(doc.GetElement(prop.PropertyName).ToJson());
                            jo.Add(prop.OutputName, (JObject) currentElement["Value"]);
                            break;
                    }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to convert from Bson to JObject ", ex);
            }

            return jo;
        }
    }
}