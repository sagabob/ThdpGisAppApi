using MediatR;
using Newtonsoft.Json.Linq;
using TdpGisApi.Configuration.Model;

namespace TdpGisApi.Application.QuerySvc.Message
{
    public class RequestMsg : IRequest<ResponseMsg<JObject>>
    {
        public RequestMsg(string searchedPhrase)
        {
            QueriedText = searchedPhrase;
        }

        public string QueriedText { get; set; }
        public QueryConfig QueriedInstance { get; set; }
        public int Limit { get; set; }
        public int Skip { get; set; }
    }
}