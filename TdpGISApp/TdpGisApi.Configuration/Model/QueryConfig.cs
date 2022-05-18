using System.Collections.Generic;

namespace TdpGisApi.Configuration.Model
{
    public class QueryConfig
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public QueryType QueryType { get; set; }

        public string QueryField { get; set; }

        public List<PropertyOutput> Mappings { get; set; }

        public DataSourceSettings
            DbSettings { get; set; } //can't use Interface IDataSourceSettings here -> need to investigate
        
        public GeometryType GeometryType { get; set; }
    }

    public enum QueryType
    {
        Text,
        Spatial
    }

    public enum GeometryType
    {
        MultiPoint,
        MultiPolygon
    }


    public enum PropertyType
    {
        Normal,
        Object
    }


    public class PropertyOutput
    {
        public int Id { get; set; }
        public PropertyType ColumnType { get; set; }
        public string PropertyName { get; set; }
        public string OutputName { get; set; }
    }
}