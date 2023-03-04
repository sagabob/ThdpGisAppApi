using System.Collections.Generic;
using TdpGisApi.Configuration.Model;

namespace TdpGisApi.Configuration.Tests;

public class FakeData
{
    public static List<QueryConfig> GetConfigurationData()
    {
        var queryConfigs = new List<QueryConfig>();

        var placeNameOutputs = new List<PropertyOutput>();

        var counter = 0;

        placeNameOutputs.Add(new PropertyOutput
        {
            Id = counter++,
            ColumnType = PropertyType.Normal,
            PropertyName = "placeNameId",
            OutputName = "Id"
        });
        ;


        placeNameOutputs.Add(new PropertyOutput
        {
            Id = counter++,
            ColumnType = PropertyType.Normal,
            PropertyName = "placeName",
            OutputName = "placeName"
        });
        ;

        placeNameOutputs.Add(new PropertyOutput
        {
            Id = counter++,
            ColumnType = PropertyType.Normal,
            PropertyName = "locality",
            OutputName = "locality"
        });

        placeNameOutputs.Add(new PropertyOutput
        {
            Id = counter,
            ColumnType = PropertyType.Object,
            PropertyName = "geometry",
            OutputName = "geometry"
        });

        var placeNameDbSettings = new DataSourceSettings
        {
            ConnectionString =
                "mongodb+srv://dbreader:dbreader@starter-7tvp1.mongodb.net/ccc_db?retryWrites=true&w=majority",
            Entity = "place_names",
            DatabaseType = SourceType.Mongodb,
            Database = "ccc_db"
        };

        queryConfigs.Add(new QueryConfig
        {
            Name = "QueryPlaceName",
            Description = "Query PlaceName collection by Name",
            QueryType = QueryType.Text,
            QueryField = "placeName",
            Mappings = placeNameOutputs,
            DbSettings = placeNameDbSettings
        });

        counter = 0; //reset counter;
        var parkOutputs = new List<PropertyOutput>
        {
            new()
            {
                Id = counter++,
                ColumnType = PropertyType.Normal,
                PropertyName = "parkId",
                OutputName = "Id"
            },

            new()
            {
                Id = counter++,
                ColumnType = PropertyType.Normal,
                PropertyName = "parkName",
                OutputName = "parkName"
            },

            new()
            {
                Id = counter++,
                ColumnType = PropertyType.Normal,
                PropertyName = "parkTypeDescription",
                OutputName = "parkType"
            },

            new()
            {
                Id = counter,
                ColumnType = PropertyType.Object,
                PropertyName = "geometry",
                OutputName = "geometry"
            }
        };

        var parkDbSettings = new DataSourceSettings
        {
            ConnectionString =
                "mongodb+srv://dbreader:dbreader@starter-7tvp1.mongodb.net/ccc_db?retryWrites=true&w=majority",
            Entity = "parks",
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


        var streetAddressDbSettings = new DataSourceSettings
        {
            ConnectionString =
                "mongodb+srv://dbreader:dbreader@starter-7tvp1.mongodb.net/ccc_db?retryWrites=true&w=majority",
            Entity = "street_addresses",
            DatabaseType = SourceType.Mongodb,
            Database = "ccc_db"
        };

        counter = 0; //reset counter;
        var streetAddressOutputs = new List<PropertyOutput>
        {
            new()
            {
                Id = counter++,
                ColumnType = PropertyType.Normal,
                PropertyName = "streetAddressId",
                OutputName = "Id"
            },

            new()
            {
                Id = counter++,
                ColumnType = PropertyType.Normal,
                PropertyName = "streetAddress",
                OutputName = "streetAddress"
            },

            new()
            {
                Id = counter++,
                ColumnType = PropertyType.Normal,
                PropertyName = "localityName",
                OutputName = "locality"
            },

            new()
            {
                Id = counter++,
                ColumnType = PropertyType.Normal,
                PropertyName = "occupationLevelDescription",
                OutputName = "occupationLevel"
            },

            new()
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
            DbSettings = streetAddressDbSettings
        });

        var ratingUnitDbSettings = new DataSourceSettings
        {
            ConnectionString =
                "mongodb+srv://dbreader:dbreader@starter-7tvp1.mongodb.net/ccc_db?retryWrites=true&w=majority",
            Entity = "ratingunits",
            DatabaseType = SourceType.Mongodb,
            Database = "ccc_db"
        };

        counter = 0; //reset counter;
        var ratingUnitOutputs = new List<PropertyOutput>
        {
            new()
            {
                Id = counter++,
                ColumnType = PropertyType.Normal,
                PropertyName = "ratingUnitId",
                OutputName = "Id"
            },

            new()
            {
                Id = counter++,
                ColumnType = PropertyType.Normal,
                PropertyName = "streetAddress",
                OutputName = "streetAddress"
            },

            new()
            {
                Id = counter++,
                ColumnType = PropertyType.Normal,
                PropertyName = "localityName",
                OutputName = "locality"
            },

            new()
            {
                Id = counter++,
                ColumnType = PropertyType.Normal,
                PropertyName = "occupationLevelDescription",
                OutputName = "occupationLevel"
            },

            new()
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
            DbSettings = ratingUnitDbSettings
        });

        return queryConfigs;
    }
}