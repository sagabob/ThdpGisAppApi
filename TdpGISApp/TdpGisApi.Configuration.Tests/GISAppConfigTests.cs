using FluentAssertions;
using NUnit.Framework;
using TdpGisApi.Configuration.Model;

namespace TdpGisApi.Configuration.Tests;

public class GisAppConfigTests
{
    private GisAppConfig _gisAppConfig;


    [SetUp]
    public void Setup()
    {
        _gisAppConfig = new GisAppConfig();
    }

    [TestCase("queryPark1", false)]
    [TestCase("queryPark", true)]
    public void Test_get_query_config_by_name(string queryName, bool expectedResult)
    {
        //arrange
        _gisAppConfig.AddQueryConfigs(FakeData.GetConfigurationData());

        //act
        var config = _gisAppConfig.GetQueryInstance(queryName);

        //assert
        if (!expectedResult)
        {
            config.Should().BeNull();
        }
        else
        {
            config.Should().NotBeNull();
            config.Name.ToLower().Should().Be(queryName.ToLower());
        }
    }
}