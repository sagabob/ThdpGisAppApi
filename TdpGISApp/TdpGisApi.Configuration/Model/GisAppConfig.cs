using System.Collections.Generic;
using System.Linq;

namespace TdpGisApi.Configuration.Model
{
    public class GisAppConfig
    {
        public const int PageNumber = 50;

        public GisAppConfig()
        {
            QueryInstances = new Dictionary<string, QueryConfig>();
            PageLimit = PageNumber; //Temporarily set it in code, will be configurable
        }

        public IDictionary<string, QueryConfig> QueryInstances { get; }

        public int PageLimit { get; set; }

        public bool IsQueryInstanceRegistered(string searchInst)
        {
            return QueryInstances.ContainsKey(searchInst.ToLower());
        }

        public QueryConfig GetQueryInstance(string queryName)
        {
            QueryInstances.TryGetValue(queryName.ToLower(), out var inst);

            return inst;
        }

        public List<QueryConfig> GetQueryConfigs()
        {
            var queryConfigs = new List<QueryConfig>();

            queryConfigs.AddRange(QueryInstances.Select(x => x.Value));

            return queryConfigs;
        }

        public List<QueryConfigDto> GetQueryConfigDto()
        {
            var queryConfigs = new List<QueryConfigDto>();

            queryConfigs.AddRange(QueryInstances.Select(x => new QueryConfigDto
            {
                Id = x.Value.Id,
                Name = x.Value.Name,
                Description = x.Value.Description,
                QueryField = x.Value.QueryField,
                QueryType = x.Value.QueryType,
                Mappings = x.Value.Mappings
            }));

            return queryConfigs;
        }

        public void AddQueryConfigs(List<QueryConfig> queryConfigs)
        {
            queryConfigs.ForEach(x => QueryInstances.Add(x.Name.ToLower(), x));
        }
    }
}