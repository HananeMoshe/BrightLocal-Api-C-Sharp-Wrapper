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