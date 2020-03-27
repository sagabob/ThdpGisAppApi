# ThdpGisAppApi
## Introduction
A dotnet-core WebApi which provides Restful services on searching geospatial features such as interested points or properties.

## Description
The WebAPi currently has 3 main routes. Please have a look at the demo link for more details http://167.71.212.250/index.html. 
1. [get] /api/gisquery/instances</br>
Return a list of query instances configured in the configuration database.
The query instance provides the database connection string, queried field and which fields will be returned.
Here is an example:
`[{"id":"5e647f2b1a67da2a385eecbd","name":"QueryPlaceName","description":"Query PlaceName collection by Name","queryType":0,"queryField":"placeName","mappings":[{"id":0,"columnType":0,"propertyName":"placeNameId","outputName":"Id"},{"id":1,"columnType":0,"propertyName":"placeName","outputName":"placeName"},{"id":2,"columnType":0,"propertyName":"locality","outputName":"locality"},{"id":3,"columnType":1,"propertyName":"geometry","outputName":"geometry"}],"dbSettings":{"connectionString":"mongodb+srv://myuser:myuser@starter-7tvp1.mongodb.net/ccc_db?retryWrites=true&w=majority","database":"ccc_db","entity":"place_names_test","databaseType":0}}]`
