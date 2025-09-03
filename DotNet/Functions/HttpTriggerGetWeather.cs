using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace CloudStrategy.Poc;

public class HttpTriggerGetWeather
{
    private readonly ILogger<HttpTriggerGetWeather> _logger;

    public HttpTriggerGetWeather(ILogger<HttpTriggerGetWeather> logger)
    {
        _logger = logger;
    }

    [Function("HttpTriggerGetWeatherAnonymous")]
    public IActionResult GetWeatherAnonymous([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        return new OkObjectResult("Anonymous - Welcome to Azure Functions!");

        //HTTP Trigger to process and cache data using Redis Cache
    }

    [Function("HttpTriggerGetWeatherFunction")]
    public IActionResult GetWeatherFunction([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        return new OkObjectResult("Function - Welcome to Azure Functions!");
    }
}