using MediatR;
using Newtonsoft.Json.Linq;
using TdpGisApi.Configuration.Model;

namespace TdpGisApi.Application.QuerySvc.Message
{
    public class MongodbSourceRequest : IRequest<ResponseMsg<JObject>>
    {
        public MongodbSourceRequest()
        {
            //Require for reflection
        }

        public MongodbSourceRequest(RequestMsg reqMsg)
        {
            ReqMsg = reqMsg;
        }

        public RequestMsg ReqMsg { get; set; }

        public static SourceType SourceDbType => SourceType.Mongodb;
    }
}