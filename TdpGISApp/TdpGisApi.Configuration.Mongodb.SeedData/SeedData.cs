using System.Collections.Generic;
using TdpGisApi.Configuration.Model;

namespace TdpGisApi.Configuration.Mongodb.SeedData
{
    public class SeedData
    {
        public static List<QueryConfig> GetConfigurationData(CollectionOfConnectStrings connectionSettings)
        {
            var queryConfigs = new List<QueryConfig>();

            var counter = 0;
            var placeNameOutputs = new List<PropertyOutput>
            {
                new PropertyOutput
                {
                    Id = counter++,
                    ColumnType = PropertyType.Normal,
                    PropertyName = "placeNameId",
                    OutputName = "Id"
                },
                new PropertyOutput
                {
                    Id = counter++,
                    ColumnType = PropertyType.Normal,
                    PropertyName = "placeName",
                    OutputName = "placeName"
                },
                new PropertyOutput
                {
                    Id = counter++,
                    ColumnType = PropertyType.Normal,
                    PropertyName = "locality",
                    OutputName = "locality"
                },
                new PropertyOutput
                {
                    Id = counter,
                    ColumnType = PropertyType.Object,
                    PropertyName = "geometry",
                    OutputName = "geometry"
                }
            };


            var placeNameDbSettings = new DataSourceSettings
            {
                ConnectionString = connectionSettings.ReadOnlyConnectionString,
                Entity = "place_names_test",
                DatabaseType = SourceType.Mongodb,
                Database = "ccc_db",
            };

            queryConfigs.Add(new QueryConfig
            {
                Name = "QueryPlaceName",
                Description = "Query PlaceName collection by Name",
                QueryType = QueryType.Text,
                QueryField = "placeName",
                Mappings = placeNameOutputs,
                DbSettings = placeNameDbSettings,
                GeometryType = GeometryType.MultiPoint
            });

            counter = 0; //reset counter;
            var parkOutputs = new List<PropertyOutput>
            {
                new PropertyOutput
                {
                    Id = counter++,
                    ColumnType = PropertyType.Normal,
                    PropertyName = "parkId",
                    OutputName = "Id"
                },

                new PropertyOutput
                {
                    Id = counter++,
                    ColumnType = PropertyType.Normal,
                    PropertyName = "parkName",
                    OutputName = "parkName"
                },

                new PropertyOutput
                {
                    Id = counter++,
                    ColumnType = PropertyType.Normal,
                    PropertyName = "parkTypeDescription",
                    OutputName = "parkType"
                },

                new PropertyOutput
                {
                    Id = counter,
                    ColumnType = PropertyType.Object,
                    PropertyName = "geometry",
                    OutputName = "geometry"
                }
            };

            var parkDbSettings = new DataSourceSettings
            {
                ConnectionString = connectionSettings.ReadOnlyConnectionString,
                Entity = "parks_test",
                DatabaseType = SourceType.Mongodb,
                Database = "ccc_db"
            };

            queryConfigs.Add(new QueryConfig
            {
                Name = "QueryPark",
                Description = "Query Park collection by Name",
                QueryType = QueryType.Text,
                QueryField = "parkName",
                Mappings = parkOutputs,
                DbSettings = parkDbSettings,
                GeometryType = GeometryType.MultiPolygon
            });


            var streetAddressDbSettings = new DataSourceSettings
            {
                ConnectionString = connectionSettings.ReadOnlyConnectionString,
                Entity = "street_addresses_test",
                DatabaseType = SourceType.Mongodb,
                Database = "ccc_db"
            };

            counter = 0; //reset counter;
            var streetAddressOutputs = new List<PropertyOutput>
            {
                new PropertyOutput
                {
                    Id = counter++,
                    ColumnType = PropertyType.Normal,
                    PropertyName = "streetAddressId",
                    OutputName = "Id"
                },

                new PropertyOutput
                {
                    Id = counter++,
                    ColumnType = PropertyType.Normal,
                    PropertyName = "streetAddress",
                    OutputName = "streetAddress"
                },

                new PropertyOutput
                {
                    Id = counter++,
                    ColumnType = PropertyType.Normal,
                    PropertyName = "localityName",
                    OutputName = "locality"
                },

                new PropertyOutput
                {
                    Id = counter++,
                    ColumnType = PropertyType.Normal,
                    PropertyName = "occupationLevelDescription",
                    OutputName = "occupationLevel"
                },

                new PropertyOutput
                {
                    Id = counter,
                    ColumnType = PropertyType.Object,
                    PropertyName = "geometry",
                    OutputName = "geometry"
                }
            };

            queryConfigs.Add(new QueryConfig
            {
                Name = "QueryAddress",
                Description = "Query StreetAddress collection by Name",
                QueryType = QueryType.Text,
                QueryField = "streetAddress",
                Mappings = streetAddressOutputs,
                DbSettings = streetAddressDbSettings,
                GeometryType = GeometryType.MultiPoint
            });

            var ratingUnitDbSettings = new DataSourceSettings
            {
                ConnectionString = connectionSettings.ReadOnlyConnectionString,
                Entity = "ratingunits",
                DatabaseType = SourceType.Mongodb,
                Database = "ccc_db"
            };

            counter = 0; //reset counter;
            var ratingUnitOutputs = new List<PropertyOutput>
            {
                new PropertyOutput
                {
                    Id = counter++,
                    ColumnType = PropertyType.Normal,
                    PropertyName = "ratingUnitId",
                    OutputName = "Id"
                },

                new PropertyOutput
                {
                    Id = counter++,
                    ColumnType = PropertyType.Normal,
                    PropertyName = "streetAddress",
                    OutputName = "streetAddress"
                },

                new PropertyOutput
                {
                    Id = counter++,
                    ColumnType = PropertyType.Normal,
                    PropertyName = "localityName",
                    OutputName = "locality"
                },

                new PropertyOutput
                {
                    Id = counter++,
                    ColumnType = PropertyType.Normal,
                    PropertyName = "occupationLevelDescription",
                    OutputName = "occupationLevel"
                },

                new PropertyOutput
                {
                    Id = counter,
                    ColumnType = PropertyType.Object,
                    PropertyName = "geometry",
                    OutputName = "geometry"
                }
            };

            queryConfigs.Add(new QueryConfig
            {
                Name = "QueryRatingUnit",
                Description = "Query RatingUnit collection by Name",
                QueryType = QueryType.Text,
                QueryField = "streetAddress",
                Mappings = ratingUnitOutputs,
                DbSettings = ratingUnitDbSettings,
                GeometryType = GeometryType.MultiPolygon
            });

            return queryConfigs;
        }
    }
}