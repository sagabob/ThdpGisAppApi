# ThdpGisAppApi
## Introduction
A dotnet-core WebApi which provides Restful services on searching geospatial features such as interested points or properties.

## Description
The WebAPi currently has 3 main routes. Please have a look at the demo link for more details http://167.71.212.250/index.html.<br/><br/>  
**1. [get] /api/gisquery/instances</br>**
Return a list of query instances configured in the configuration database.
The query instance provides the name of the instance, database connection string, database type (0 for Mongodb or 1 for MsSQL), queried field and which fields will be returned.
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
    "connectionString": "mongodb+srv://myuser:myuser@starter-7tvp1.mongodb.net/ccc_db?retryWrites=true&w=majority",
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
<br/>

**2. [get] /api/GisQuery/querybytext/{queryName}/{queriedPhrase}/{pageLimit}</br>**
Use the query instance information such as query name provided in the first query as input. The queriedPhrase is the phrase that you want to search and the pageLimit indicates the number of records we want to get. An example of the Url is /api/gisquery/queryPlaceName/garden/50

