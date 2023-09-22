[![LinkedIn][linkedin-shield]][linkedin-url]

<!-- PROJECT LOGO -->
<br />
<p align="center">
  <a href="#">
    <img src="https://i.ibb.co/gb2tf3s/Tdp-logo-main.png" alt="Logo" width="285" height="170">
  </a>

  <h2 align="center">Tdp GIS API</h2>

  <p align="center">
    A Restful Api providing querying services for configured geospatial features
    <br />  
    <a href="https://thdp-gis-api.azurewebsites.net/index.html" target="_blank"><strong>Explore the api »</strong></a>   
    <br />  
    <a href="https://thdp-gis-webapp.vercel.app/" target="_blank"><strong>Explore the web app using the api »</strong></a>   
  </p>
</p>
 
## Table of Contents

* [About the Project](#about-the-project)
* [Built with](#built-with)
* [Usage](#usage)
* [Getting Started](#getting-started)
  * [Prerequisites](#Prerequisites)
  * [Installation](#Installation)
* [CI/CD](#continuous-development-delivery)
* [Roadmap](#roadmap)
* [Contact](#contact)
  
## About the project
A dotnet-core WebApi which provides Restful services on searching geospatial features such as interested points or properties. Currently, querying features by input phrase is implemented. 

## Built With
This WebApi is designed with domain driven development. Here is the highlight of design patterns and frameworks used in the application 
* [MediatoR](https://github.com/jbogard/MediatR)
  <br/>Decouple input query object from its handler, and also decouple again the handler to different feature sources. 
* [Mongodb](https://www.mongodb.com/)
  <br/>Current use Mongodb to store configuration and feature data.
* [WebApi HealthCheck](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/monitor-app-health)
* [Swagger](https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger?view=aspnetcore-3.1)

## Usage
The WebAPi currently has 3 main routes. Please have a look at the api document https://gisapi.tdp-store.info/index.html for more details. The demo webapp using these Api can be accessed here https://giswebapp.tdp-store.info/

**1. [get] /api/gisquery/instances</br>**
Return a list of query instances configured in the configuration database.
The query instance provides the name of the instance, database connection string, database type (0 for Mongodb), queried field and output fields.
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
  ]  
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
The {queryName} is the name of the query instance provided in the first route, in this case is queryName. The {queriedPhrase} is the phrase that you want to search and the pageLimit indicates the number of records we want to get. An example of the Url is _/api/gisquery/queryPlaceName/garden/50_

**3. [get] /api/GisQuery/querybytext/{queryName}/{queriedPhrase}/{pageLimit}/{pageOrder}</br>**
An extend of the previous one, {pageOrder} is the page number, starts with 1.


## Getting Started
### Prerequisites
The current version requires an environment with dotnet-core 3.0. Mongodb is also necessary. 

### Installation

1. Clone the repo
2. Restore solution

## Continuous Development Delivery
* For CI: The solution is built and the docker is deployed to Docker Hub private repository.<br/>
[![Build Status](https://dev.azure.com/bobpham-tdp-saga/TdpAGISApp/_apis/build/status/TdpAGISApp-CI-Dev?branchName=dev)](https://dev.azure.com/bobpham-tdp-saga/TdpAGISApp/_build/latest?definitionId=35&branchName=dev)
* For CD: The docker is then deployed as a Digital Ocean App.<br/>
[![Deployment Status](https://vsrm.dev.azure.com/bobpham-tdp-saga/_apis/public/Release/badge/a01d75dd-db1b-4bf9-8906-14b01aedad54/3/3)](https://vsrm.dev.azure.com/bobpham-tdp-saga/_apis/public/Release/badge/a01d75dd-db1b-4bf9-8906-14b01aedad54/3/3)


## Roadmap
The application will be extended with the following features
* Query features by coordinates (input long & lat)
* Add Kubernetes.
* Add authentication/authorization.



## Contact
[![LinkedIn][linkedin-shield]][linkedin-url]<br/>
Bob Pham - bobpham.tdp@gmail.com<br/>


[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=flat-square&logo=linkedin&colorB=555
[linkedin-url]: https://www.linkedin.com/in/bob-pham-93937973/
[tdp-logo]: tdp-logo.png
