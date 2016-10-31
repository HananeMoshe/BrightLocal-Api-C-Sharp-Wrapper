# BrightLocal-Api-C-Sharp-Wrapper
Bright Local Api C# Wrapper

A c# wrapper class for consuming The Bright Local api. Automatically generates the proper authentication, with the siganture and expires. Avoid the need to generate your own authetication signature.

##Dependencies

It is recommended you install the following dependencies via NuGet.

1. RestSHarp: nuget Install-Package RestSharp | Git: https://github.com/restsharp/RestSharp

2. Json.NET: nuget Install-Package Newtonsoft.Json -Version 9.0.1 | Git: https://github.com/JamesNK/Newtonsoft.Json



Clients
-----

### Creating a client

```csharp
    api request = new api("<INSERT_API_KEY>", "<INSERT_API_SECRET>");

    var parameters = new api.Parameters();
           parameters.Add("name", "Le Bernardin");
           parameters.Add("company-url", "http://www.example.com");
           parameters.Add("business-category-id", "791");

    var success = request.Post("v1/clients-and-locations/clients/", parameters);
```

### Update a client

```csharp
    api request = new api("<INSERT_API_KEY>", "<INSERT_API_SECRET>");

    var parameters = new api.Parameters();
           parameters.Add("client-id", "36447");
           parameters.Add("name", "Le Bernardin Caffe");

    var success = request.Put("v1/clients-and-locations/clients/", parameters);
```

### Delete a client

```csharp
    api request = new api("<INSERT_API_KEY>", "<INSERT_API_SECRET>");

    var parameters = new api.Parameters();
           parameters.Add("client-id", "36447");
                  
    var success = request.Delete("v1/clients-and-locations/clients/", parameters);
```

### Get a client

```csharp
    api request = new api("<INSERT_API_KEY>", "<INSERT_API_SECRET>");

    var parameters = new api.Parameters();
    var clientId = 36447;
    var success = request.Get("v1/clients-and-locations/clients/" + clientId + "", parameters);
```

### Search for a client

```csharp
    api request = new api("<INSERT_API_KEY>", "<INSERT_API_SECRET>");

    var parameters = new api.Parameters();
           parameters.Add("q", "My Sample Query");      
		         
    var success = request.Put("v1/clients-and-locations/clients/search", parameters);
```

Locations
-----

### Creating a Location

```csharp
    api request = new api("<INSERT_API_KEY>", "<INSERT_API_SECRET>");

    var parameters = new api.Parameters();
           parameters.Add("name", "Le Bernardin");
           parameters.Add("url", "http://le-bernardin.com");
           parameters.Add("business-category-id", "605");
           parameters.Add("country", "USA"); // 3 Letter iso code
           parameters.Add("address1", "155 Weest 51st Street");
           parameters.Add("address2", "");
           parameters.Add("region", "NY"); // State or Region
           parameters.Add("city", "New York");
           parameters.Add("postcode", "10019");
           parameters.Add("telephone", "+1 212-554-1515");

    var success = request.Post("v1/clients-and-locations/locations/", parameters);
```

### Update a location

```csharp
    api request = new api("<INSERT_API_KEY>", "<INSERT_API_SECRET>");

	var locationId = 1;
    var parameters = new api.Parameters();
           parameters.Add("name", "Le Bernardin");
           parameters.Add("url", "http://le-bernardin.com");
           parameters.Add("business-category-id", "605");
           parameters.Add("country", "USA"); // 3 Letter iso code
           parameters.Add("address1", "155 Weest 51st Street");
           parameters.Add("address2", "");
           parameters.Add("region", "NY"); // State or Region
           parameters.Add("city", "New York");
           parameters.Add("postcode", "10019");
           parameters.Add("telephone", "+1 212-554-1515");

    var success = request.Put("v1/clients-and-locations/locations/" + locationId + "", parameters);
```

### Get Location

```csharp
    api request = new api("<INSERT_API_KEY>", "<INSERT_API_SECRET>");

    var locationId = 1;
    var parameters = new api.Parameters();

    var success = request.Get("v1/clients-and-locations/locations/" + locationId + "", parameters);
```
### Search Locations

```csharp
    api request = new api("<INSERT_API_KEY>", "<INSERT_API_SECRET>");

    var parameters = new api.Parameters();
           parameters.Add("q", "My Sample Query");

    var success = request.Get("v1/clients-and-locations/locations/search", parameters);
```

### Delete a Location

```csharp
    api request = new api("<INSERT_API_KEY>", "<INSERT_API_SECRET>");

    var locationId = 1;
    var parameters = new api.Parameters();           

    var success = request.Delete("v1/clients-and-locations/locations/" + locationId + "", parameters);
```
