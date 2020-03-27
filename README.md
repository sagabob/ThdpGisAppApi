# ThdpGisAppApi
## Introduction
A dotnet-core WebApi which provides Restful services on searching geospatial features such as interested points or properties.

## Build With
This WebApi is designed with domain driven development. Here is the highlight of design patterns and frameworks used in the application 
* [MediatoR](https://github.com/jbogard/MediatR)
  <br/>Decouple input query object from its handler, and also decouple again the handler to different feature sources. 
* [Mongodb](https://www.mongodb.com/)
  <br/>Current use Mongodb to store configuration and feature data.
* [WebApi HealthCheck](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/monitor-app-health)
* [Swagger](https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger?view=aspnetcore-3.1)

## Usage
The WebAPi currently has 3 main routes. Please have a look at the demo link for more details http://167.71.212.250/index.html.

**1. [get] /api/gisquery/instances</br>**
Return a list of query instances configured in the configuration database.
The query instance provides the name of the instance, database connection string, database type (0 for Mongodb or 1 for MsSQL), queried field and output fields.
Here is an example of a query instance for Place Name feature:
```
{
  "id": "5e647f2b1a67da2a385eecbd",
  "name": "QueryPlaceName",
  "description": "Query PlaceName collection by Name",
  "queryType": 0,
  "queryField": "placeName",
  "mappings": [
    {
      "id": 0,
      "columnType": 0,
      "propertyName": "placeNameId",
      "outputName": "Id"
    },
    {
      "id": 1,
      "columnType": 0,
      "propertyName": "placeName",
      "outputName": "placeName"
    },
    {
      "id": 2,
      "columnType": 0,
      "propertyName": "locality",
      "outputName": "locality"
    },
    {
      "id": 3,
      "columnType": 1,
      "propertyName": "geometry",
      "outputName": "geometry"
    }
  ],
  "dbSettings": {
    "connectionString": "mongodb+srv://xxx:xxx@mongodb/xxxdb?retryWrites=true&w=majority",
    "database": "ccc_db",
    "entity": "place_names_test",
    "databaseType": 0
  }
}

```
Here is the detail of an instance of the Place Name feature
```
{
  "_id": "5b418df63d88413b6ca9d918",
  "placeNameId": 1,
  "placeName": "Aberfoyle Courts",
  "locality": "Queenspark",
  "geometry": {
    "type": "MultiPoint",
    "coordinates": [
      [
        172.70793,
        -43.48352
      ]
    ]
  }
}
```

**2. [get] /api/GisQuery/querybytext/{queryName}/{queriedPhrase}/{pageLimit}</br>**
The {queryName} is the name of the query instance provided in the first route, in this case is queryName. The {queriedPhrase} is the phrase that you want to search and the pageLimit indicates the number of records we want to get. An example of the Url is /api/gisquery/queryPlaceName/garden/50

**3. [get] /api/GisQuery/querybytext/{queryName}/{queriedPhrase}/{pageLimit}/{pageOrder}</br>**
An extend of the previous one, {pageOrder} is the page number, starts with 1.



