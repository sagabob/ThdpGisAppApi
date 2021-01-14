using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Threading.Tasks;
using TdpGisApi.Application.QuerySvc.DataSvc;
using TdpGisApi.Application.QuerySvc.Mapping;
using TdpGisApi.Application.QuerySvc.Message;

namespace TdpGisApi.Application.QuerySvc.Handler
{
    public class MongodbSourceHandler : IRequestHandler<MongodbSourceRequest, ResponseMsg<JObject>>
    {
        private readonly ILogger _logger;
        private readonly IOutputMapping _mapping;
        private readonly IMongodbService _service;

        public MongodbSourceHandler(ILogger<MongodbSourceHandler> logger, IOutputMapping mapping,
            IMongodbService service)
        {
            _logger = logger;

            _mapping = mapping;

            _service = service;
        }

        public Task<ResponseMsg<JObject>> Handle(MongodbSourceRequest request, CancellationToken cancellationToken)
        {
            ResponseMsg<JObject> output = new ResponseMsg<JObject>();

            _logger.LogInformation("Start querying from Mongodb source..", request);

            _service.Init(request.ReqMsg.QueriedInstance.DbSettings);

            System.Collections.Generic.List<JObject> queriedResult = _service.QueryTextWithMapping(request.ReqMsg.QueriedInstance.QueryField,
                request.ReqMsg.QueriedText, request.ReqMsg.Limit, request.ReqMsg.Skip,
                request.ReqMsg.QueriedInstance.Mappings, _mapping);

            output.Results = queriedResult;
            output.Skip = request.ReqMsg.Skip;
            output.Limit = request.ReqMsg.Limit;

            return Task.FromResult(output);
        }
    }
}