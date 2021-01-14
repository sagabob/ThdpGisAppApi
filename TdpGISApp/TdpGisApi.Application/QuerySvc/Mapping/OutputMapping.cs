using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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
            List<JObject> jObjects = new List<JObject>();
            queryResult.ForEach(x => { jObjects.Add(ConvertFromBson(x, maps)); });

            return jObjects;
        }

        public JObject ConvertFromBson(BsonDocument doc, List<PropertyOutput> maps)
        {
            JObject jo = new JObject();
            try
            {
                foreach (PropertyOutput prop in maps)
                {
                    switch (prop.ColumnType)
                    {
                        case PropertyType.Normal:
                            jo.Add(prop.OutputName, doc.GetValue(prop.PropertyName).ToString());
                            break;

                        case PropertyType.Object:
                            //work around the problem due to JObject parse BsonDocument ToJson function
                            JObject currentElement = JObject.Parse(doc.GetElement(prop.PropertyName).ToJson());
                            jo.Add(prop.OutputName, (JObject)currentElement["Value"]);
                            break;
                    }
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