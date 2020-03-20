using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using TdpGisApi.Application.QuerySvc.DataSvc;
using TdpGisApi.Configuration.Model;

namespace TdpGisApi.Application.Config
{
    public class QueryConfigurationMongodbValidator : IQueryConfigureValidator
    {
        private readonly IMongodbService _dbService;
        private readonly ILogger _logger;

        public QueryConfigurationMongodbValidator(ILogger<QueryConfigurationMongodbValidator> logger,
            IMongodbService dbService)
        {
            _logger = logger;
            _dbService = dbService;
        }

        public ValidatingResult ValidateAllQueryConfiguration(GisAppConfig appConfigInstance)
        {
            _logger.LogInformation("Start validating GIS Query Data configuration");
            var result = new ValidatingResult {Status = true};
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            try
            {
                foreach (var pairConfig in appConfigInstance.QueryInstances.Values)
                    ValidateQueryConfiguration(pairConfig);
            }
            catch (Exception ex)
            {
                _logger.LogError("Validation failed due to the exception", ex);
                result.OutputException = ex;
                result.Status = false;
            }
            finally
            {
                stopWatch.Stop();
                result.ResponseTime = stopWatch.ElapsedMilliseconds;
                result.Description =
                    "Checking search data configuration"; //TODO it can be configurable, getting from database
            }

            return result;
        }

        public void ValidateQueryConfiguration(QueryConfig queryConfig)
        {
            _dbService.Init(queryConfig.DbSettings);

            var isExisted = _dbService.CollectionExists(queryConfig.DbSettings.Entity);

            if (!isExisted)
            {
                _logger.LogError($"Collection {queryConfig.DbSettings.Entity} doesn't exist");
                throw new ArgumentException($"Collection {queryConfig.DbSettings.Entity} doesn't exist");
            }


            var singleDoc = _dbService.GetOneDocument(queryConfig.DbSettings.Entity);

            if (!ValidateOutputMapping(singleDoc, queryConfig.Mappings))
            {
                _logger.LogError($"Output mapping of {queryConfig.Name} has invalid column");
                throw new ArgumentException($"Output mapping of {queryConfig.Name} has invalid column");
            }


            if (!ValidateQueryField(singleDoc, queryConfig.QueryField))
            {
                _logger.LogError($"Query Field of {queryConfig.Name} doesn't match with any document fields");
                throw new ArgumentException(
                    $"Query Field of {queryConfig.Name} doesn't match with any document fields");
            }
        }

        /// <summary>
        ///     Check whether the input list of outputs are valid
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="maps"></param>
        /// <returns></returns>
        public bool ValidateOutputMapping(BsonDocument doc, List<PropertyOutput> maps)
        {
            var counter = maps.Count;
            foreach (var prop in maps)
            foreach (var ele in doc.Elements)
                if (ele.Name == prop.PropertyName)
                {
                    counter--;
                    break;
                }

            return counter == 0;
        }

        /// <summary>
        ///     Check whether the input queryField is a valid field of the document
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="queriedField"></param>
        /// <returns></returns>
        public bool ValidateQueryField(BsonDocument doc, string queriedField)
        {
            foreach (var ele in doc.Elements)
                if (ele.Name == queriedField)
                    return true;
            return false;
        }
    }
}