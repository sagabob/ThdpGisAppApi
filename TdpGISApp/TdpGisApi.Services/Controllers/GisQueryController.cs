using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TdpGisApi.Application.QuerySvc.Message;
using TdpGisApi.Configuration.Model;
using TdpGisApi.Services.Utility;

namespace TdpGisApi.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GisQueryController : ControllerBase
    {
        private readonly GisAppConfig _appConfigInstance;
        private readonly ILogger _logger;
        private readonly IMediator _mediator;
        private readonly VersionInformation _versionInformation;

        /// <summary>
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="appConfigInstance"></param>
        /// <param name="versionInformation"></param>
        /// <param name="logger"></param>
        public GisQueryController(IMediator mediator, GisAppConfig appConfigInstance,
            VersionInformation versionInformation,
            ILogger<GisQueryController> logger)
        {
            _mediator = mediator;
            _appConfigInstance = appConfigInstance;
            _versionInformation = versionInformation;
            _logger = logger;
        }


        [HttpGet("info")]
        public IActionResult GetQueryConfig()
        {
            return Ok(_versionInformation);
        }

        [HttpGet]
        [Route("instances")]
        public IActionResult Instances()
        {
            return Ok(_appConfigInstance.GetQueryConfigDtos());
        }

        [HttpGet("querybytext/{queryName}/{queriedPhrase}/{pageLimit:int=50}", Name = "QueryByText")]
        public async Task<IActionResult> QueryByText(string queryName, string queriedPhrase, int pageLimit)
        {
            var queryInst = _appConfigInstance.GetQueryInstance(queryName);

            _logger.LogDebug("SearchByTextCtrl: Found the query {queryName}", queryName);

            if (queryInst == null)
                return NotFound();

            var requestMsg = new RequestMsg(queriedPhrase)
            {
                QueriedInstance = queryInst,
                Limit = pageLimit,
                Skip = 0
            };

            var result = await _mediator.Send(requestMsg);

            return result != null ? (IActionResult) Ok(result) : BadRequest();
        }


        [HttpGet("querybytextwithpaging/{queryName}/{queriedPhrase}/{pageLimit}/{pageOrder}",
            Name = "QueryByTextWithPaging")]
        public async Task<IActionResult> QueryByTextWithPaging(string queryName, string queriedPhrase, int pageLimit,
            int pageOrder)
        {
            var queryInst = _appConfigInstance.GetQueryInstance(queryName);

            _logger.LogInformation("QueryByTextCtrl: Found the query {queryName}", queryName);

            if (queryInst == null)
            {
                _logger.LogDebug("QueryByTextCtrl: Not found the query {queryName}", queryName);
                return NotFound();
            }

            var requestMsg = new RequestMsg(queriedPhrase)
            {
                QueriedInstance = queryInst,
                Limit = pageLimit,
                Skip = Math.Max(pageOrder - 1, 0)
            };

            var result = await _mediator.Send(requestMsg);

            return result != null ? (IActionResult) Ok(result) : BadRequest();
        }
    }
}