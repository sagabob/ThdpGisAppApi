using System.Collections.Generic;

namespace TdpGisApi.Configuration.Model
{
    public class QueryConfigDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public QueryType QueryType { get; set; }

        public string QueryField { get; set; }

        public List<PropertyOutput> Mappings { get; set; }

        public GeometryType GeometryType { get; set; }
    }
}