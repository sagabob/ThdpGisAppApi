using System.Collections.Generic;
using TdpGisApi.Configuration.Model;

namespace TdpGisApi.Configuration.Tests
{
    public class FakeData
    {
        public static List<QueryConfig> GetConfigurationData()
        {
            var queryConfigs = new List<QueryConfig>();

            var placenameOutputs = new List<PropertyOutput>();

            var counter = 0;

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

            var placeNameDbSettings = new DataSourceSettings
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
            var parkOutputs = new List<PropertyOutput>();

            parkOutputs.Add(new PropertyOutput
            {
                Id = counter++,
                ColumnType = PropertyType.Normal,
                PropertyName = "parkId",
                OutputName = "Id"
            });

            parkOutputs.Add(new PropertyOutput
            {
                Id = counter++,
                ColumnType = PropertyType.Normal,
                PropertyName = "parkName",
                OutputName = "parkName"
            });

            parkOutputs.Add(new PropertyOutput
            {
                Id = counter++,
                ColumnType = PropertyType.Normal,
                PropertyName = "parkTypeDescription",
                OutputName = "parkType"
            });

            parkOutputs.Add(new PropertyOutput
            {
                Id = counter++,
                ColumnType = PropertyType.Object,
                PropertyName = "geometry",
                OutputName = "geometry"
            });

            var parkDbSettings = new DataSourceSettings
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


            var stretaddressDbSettings = new DataSourceSettings
            {
                ConnectionString =
                    "mongodb+srv://dbreader:dbreader@starter-7tvp1.mongodb.net/ccc_db?retryWrites=true&w=majority",
                Entity = "street_addresses_test",
                DatabaseType = SourceType.Mongodb,
                Database = "ccc_db"
            };

            counter = 0; //reset counter;
            var streetaddressOutputs = new List<PropertyOutput>();

            streetaddressOutputs.Add(new PropertyOutput
            {
                Id = counter++,
                ColumnType = PropertyType.Normal,
                PropertyName = "streetAddressId",
                OutputName = "Id"
            });

            streetaddressOutputs.Add(new PropertyOutput
            {
                Id = counter++,
                ColumnType = PropertyType.Normal,
                PropertyName = "streetAddress",
                OutputName = "streetAddress"
            });

            streetaddressOutputs.Add(new PropertyOutput
            {
                Id = counter++,
                ColumnType = PropertyType.Normal,
                PropertyName = "localityName",
                OutputName = "locality"
            });

            streetaddressOutputs.Add(new PropertyOutput
            {
                Id = counter++,
                ColumnType = PropertyType.Normal,
                PropertyName = "occupationLevelDescription",
                OutputName = "occupationLevel"
            });

            streetaddressOutputs.Add(new PropertyOutput
            {
                Id = counter++,
                ColumnType = PropertyType.Object,
                PropertyName = "geometry",
                OutputName = "geometry"
            });

            queryConfigs.Add(new QueryConfig
            {
                Name = "QueryAddress",
                Description = "Query StreetAddress collection by Name",
                QueryType = QueryType.Text,
                QueryField = "streetAddress",
                Mappings = streetaddressOutputs,
                DbSettings = stretaddressDbSettings
            });

            var ratingunitDbSettings = new DataSourceSettings
            {
                ConnectionString =
                    "mongodb+srv://dbreader:dbreader@starter-7tvp1.mongodb.net/ccc_db?retryWrites=true&w=majority",
                Entity = "ratingunits_test",
                DatabaseType = SourceType.Mongodb,
                Database = "ccc_db"
            };

            counter = 0; //reset counter;
            var ratingunitOutputs = new List<PropertyOutput>();


            ratingunitOutputs.Add(new PropertyOutput
            {
                Id = counter++,
                ColumnType = PropertyType.Normal,
                PropertyName = "ratingUnitId",
                OutputName = "Id"
            });

            ratingunitOutputs.Add(new PropertyOutput
            {
                Id = counter++,
                ColumnType = PropertyType.Normal,
                PropertyName = "streetAddress",
                OutputName = "streetAddress"
            });

            ratingunitOutputs.Add(new PropertyOutput
            {
                Id = counter++,
                ColumnType = PropertyType.Normal,
                PropertyName = "localityName",
                OutputName = "locality"
            });

            ratingunitOutputs.Add(new PropertyOutput
            {
                Id = counter++,
                ColumnType = PropertyType.Normal,
                PropertyName = "occupationLevelDescription",
                OutputName = "occupationLevel"
            });

            ratingunitOutputs.Add(new PropertyOutput
            {
                Id = counter++,
                ColumnType = PropertyType.Object,
                PropertyName = "geometry",
                OutputName = "geometry"
            });

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