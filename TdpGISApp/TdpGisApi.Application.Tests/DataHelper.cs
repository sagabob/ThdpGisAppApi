using System.Collections.Generic;
using MongoDB.Bson;
using TdpGisApi.Configuration.Model;

namespace TdpGisApi.Application.Tests
{
    public class DataHelper
    {
        public static BsonDocument CreateBJson()
        {
            var bson = new BsonDocument
            {
                new BsonElement("placeName", "Christchurch"),
                new BsonElement("placeNameId", 3)
            };

            var rootGeometry = new BsonArray
            {
                new BsonDocument
                {
                    {"type", "Multipoint"},

                    {
                        "coordinates", new BsonArray(new BsonArray
                        {
                            173, 43
                        })
                    }
                }
            };

            bson.Add("geometry", rootGeometry);

            return bson;
        }


        public static List<PropertyOutput> Maps()
        {
            var maps = new List<PropertyOutput>
            {
                new PropertyOutput
                {
                    ColumnType = PropertyType.Normal,
                    PropertyName = "placeName",
                    OutputName = "PlaceName"
                },

                new PropertyOutput
                {
                    ColumnType = PropertyType.Object,
                    PropertyName = "geometry",
                    OutputName = "geometry"
                }
            };

            return maps;
        }
    }
}