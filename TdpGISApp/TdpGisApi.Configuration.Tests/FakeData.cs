using System.Collections.Generic;
using TdpGisApi.Configuration.Model;

namespace TdpGisApi.Configuration.Tests
{
    public class FakeData
    {
        public static List<QueryConfig> GetConfigurationData()
        {
            List<QueryConfig> queryConfigs = new List<QueryConfig>();

            List<PropertyOutput> placenameOutputs = new List<PropertyOutput>();

            int counter = 0;

            placenameOutputs.Add(new PropertyOutput
            {
                Id = counter++,
                ColumnType = PropertyType.Normal,
                PropertyName = "placeNameId",
                OutputName = "Id"
            });
            ;


            placenameOutputs.Add(new PropertyOutput
            {
                Id = counter++,
                ColumnType = PropertyType.Normal,
                PropertyName = "placeName",
                OutputName = "placeName"
            });
            ;

            placenameOutputs.Add(new PropertyOutput
            {
                Id = counter++,
                ColumnType = PropertyType.Normal,
                PropertyName = "locality",
                OutputName = "locality"
            });

            placenameOutputs.Add(new PropertyOutput
            {
                Id = counter++,
                ColumnType = PropertyType.Object,
                PropertyName = "geometry",
                OutputName = "geometry"
            });

            DataSourceSettings placeNameDbSettings = new DataSourceSettings
            {
                ConnectionString =
                    "mongodb+srv://dbreader:dbreader@starter-7tvp1.mongodb.net/ccc_db?retryWrites=true&w=majority",
                Entity = "place_names_test",
                DatabaseType = SourceType.Mongodb,
                Database = "ccc_db"
            };

            queryConfigs.Add(new QueryConfig
            {
                Name = "QueryPlaceName",
                Description = "Query PlaceName collection by Name",
                QueryType = QueryType.Text,
                QueryField = "placeName",
                Mappings = placenameOutputs,
                DbSettings = placeNameDbSettings
            });

            counter = 0; //reset counter;
            List<PropertyOutput> parkOutputs = new List<PropertyOutput>
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
                    Id = counter++,
                    ColumnType = PropertyType.Object,
                    PropertyName = "geometry",
                    OutputName = "geometry"
                }
            };

            DataSourceSettings parkDbSettings = new DataSourceSettings
            {
                ConnectionString =
                    "mongodb+srv://dbreader:dbreader@starter-7tvp1.mongodb.net/ccc_db?retryWrites=true&w=majority",
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
                DbSettings = parkDbSettings
            });


            DataSourceSettings stretaddressDbSettings = new DataSourceSettings
            {
                ConnectionString =
                    "mongodb+srv://dbreader:dbreader@starter-7tvp1.mongodb.net/ccc_db?retryWrites=true&w=majority",
                Entity = "street_addresses_test",
                DatabaseType = SourceType.Mongodb,
                Database = "ccc_db"
            };

            counter = 0; //reset counter;
            List<PropertyOutput> streetaddressOutputs = new List<PropertyOutput>
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
                    Id = counter++,
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
                Mappings = streetaddressOutputs,
                DbSettings = stretaddressDbSettings
            });

            DataSourceSettings ratingunitDbSettings = new DataSourceSettings
            {
                ConnectionString =
                    "mongodb+srv://dbreader:dbreader@starter-7tvp1.mongodb.net/ccc_db?retryWrites=true&w=majority",
                Entity = "ratingunits_test",
                DatabaseType = SourceType.Mongodb,
                Database = "ccc_db"
            };

            counter = 0; //reset counter;
            List<PropertyOutput> ratingunitOutputs = new List<PropertyOutput>
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
                    Id = counter++,
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
                Mappings = ratingunitOutputs,
                DbSettings = ratingunitDbSettings
            });

            return queryConfigs;
        }
    }
}