using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using TdpGisApi.Application.QuerySvc.Factory;
using TdpGisApi.Application.QuerySvc.Message;

namespace TdpGisApi.Application.QuerySvc.Handler
{
    public class QueryHandler : IRequestHandler<RequestMsg, ResponseMsg<JObject>>
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;
        private readonly QueryRegister _queryRegister;

        public QueryHandler(IMediator mediator, QueryRegister queryRegister, ILogger<QueryHandler> logger)
        {
            _mediator = mediator;
            _queryRegister = queryRegister;
            _logger = logger;
        }

        public async Task<ResponseMsg<JObject>> Handle(RequestMsg request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Start getting the matched handler", request);

            var targetType = _queryRegister.Get(request.QueriedInstance.DbSettings.DatabaseType);

            var targetRequest = Activator.CreateInstance(targetType, request);

            var result = await _mediator.Send((IRequest<ResponseMsg<JObject>>) targetRequest, cancellationToken);

            return result;
        }
    }
}