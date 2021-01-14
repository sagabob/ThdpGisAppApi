using FluentAssertions;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using Moq;
using NUnit.Framework;
using System;
using TdpGisApi.Application.Config;
using TdpGisApi.Application.QuerySvc.DataSvc;
using TdpGisApi.Configuration.Model;

namespace TdpGisApi.Application.Tests
{
    [TestFixture]
    public class SearchConfigurationMongodbValidatorTests
    {
        [OneTimeSetUp]
        public void Setup()
        {
            _mockLogger = new Mock<ILogger<QueryConfigurationMongodbValidator>>();
            _mockDbSvc = new Mock<IMongodbService>();
            _validator = new QueryConfigurationMongodbValidator(_mockLogger.Object, _mockDbSvc.Object);
        }

        private Mock<ILogger<QueryConfigurationMongodbValidator>> _mockLogger;

        private QueryConfigurationMongodbValidator _validator;

        private Mock<IMongodbService> _mockDbSvc;


        public QueryConfig CreateQueryConfig()
        {
            DataSourceSettings parkDbSettings = new DataSourceSettings
            {
                ConnectionString =
                    "mongodb+srv://dbreader:dbreader@starter-7tvp1.mongodb.net/ccc_db?retryWrites=true&w=majority",
                Entity = "parks_test",
                DatabaseType = SourceType.Mongodb,
                Database = "ccc_db"
            };

            QueryConfig queryConfig = new QueryConfig
            {
                Mappings = DataHelper.Maps(),
                DbSettings = parkDbSettings,
                QueryField = "geometry"
            };

            return queryConfig;
        }

        public GisAppConfig CreateGisAppConfig()
        {
            GisAppConfig gisAppConfig = new GisAppConfig();
            gisAppConfig.QueryInstances.Add("test", CreateQueryConfig());

            return gisAppConfig;
        }

        [TestCase("geometry", true)]
        [TestCase("placeName", true)]
        [TestCase("Placename", false)]
        [TestCase("placename", false)]
        public void ValidateQueryField_return_true_when_found_the_matched_query_field_from_elements(string queriedField,
            bool expectedResult)
        {
            //Arrange
            BsonDocument bson = DataHelper.CreateBJson();
            //Act
            bool validatedResult = _validator.ValidateQueryField(bson, queriedField);
            //Assert
            validatedResult.Should().Be(expectedResult);
        }


        [TestCase("placeName1", false)]
        [TestCase("placeName", true)]
        [TestCase("Placename", false)]
        [TestCase("placename", false)]
        public void ValidateOutputMapping_return_false_when_one_mapped_property_not_found(string inputPropertyName,
            bool expectedResult)
        {
            //Arranage
            System.Collections.Generic.List<PropertyOutput> maps = DataHelper.Maps();
            maps[0].PropertyName = inputPropertyName;

            _validator.ValidateOutputMapping(DataHelper.CreateBJson(), maps).Should().Be(expectedResult);
        }

        [Test]
        public void ValidateAllQueryConfigurationTest_return_false_if_there_is_exception()
        {
            GisAppConfig gisAppConfig = CreateGisAppConfig();

            _mockDbSvc.Setup(x => x.CollectionExists(It.IsAny<string>())).Returns(true);

            _mockDbSvc.Setup(x => x.GetOneDocument(It.IsAny<string>())).Returns(DataHelper.CreateBJson());

            gisAppConfig.QueryInstances["test"].QueryField = "fake";

            ValidatingResult result = _validator.ValidateAllQueryConfiguration(gisAppConfig);

            result.Status.Should().Be(false);
        }

        [Test]
        public void ValidateAllQueryConfigurationTest_return_true_if_there_is_no_exception()
        {
            GisAppConfig gisAppConfig = CreateGisAppConfig();

            _mockDbSvc.Setup(x => x.CollectionExists(It.IsAny<string>())).Returns(true);

            _mockDbSvc.Setup(x => x.GetOneDocument(It.IsAny<string>())).Returns(DataHelper.CreateBJson());

            ValidatingResult result = _validator.ValidateAllQueryConfiguration(gisAppConfig);

            result.Status.Should().Be(true);
        }

        [Test]
        public void ValidateQueryConfigurationTest_not_throw_exception_if_config_correct()
        {
            _mockDbSvc.Setup(x => x.CollectionExists(It.IsAny<string>())).Returns(true);

            _mockDbSvc.Setup(x => x.GetOneDocument(It.IsAny<string>())).Returns(DataHelper.CreateBJson());


            QueryConfig queryConfig = CreateQueryConfig();

            Action test = () => _validator.ValidateQueryConfiguration(queryConfig);

            test.Should().NotThrow<Exception>();
        }


        [Test]
        public void ValidateQueryConfigurationTest_throw_exception_if_not_proper_document_returns()
        {
            _mockDbSvc.Setup(x => x.CollectionExists(It.IsAny<string>())).Returns(true);

            _mockDbSvc.Setup(x => x.GetOneDocument(It.IsAny<string>())).Returns(new BsonDocument());

            QueryConfig queryConfig = CreateQueryConfig();

            Action test = () => _validator.ValidateQueryConfiguration(queryConfig);

            test.Should().Throw<Exception>();
        }
    }
}