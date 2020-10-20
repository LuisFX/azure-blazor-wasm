using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Api
{
    public static class WeatherForecast
    {
        public static readonly Random random = new Random();
        public static readonly string[] summaries = new string[] {
            "Freezing",
            "Bracing",
            "Balmy",
            "Chilly"
        };
        
        // This function will create 5 random weather forecasts, matching the format of Client/wwwroot/sample-data/weather.json
        [FunctionName("WeatherForecast")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            var forecasts = new object[5];
            var currentDate = DateTime.Today;
            for (int i = 0; i < 5; i++)
            {
                var futureDate = currentDate.AddDays(i);
                var temperatureC = random.Next(-10, 35);
                forecasts[i] = new {
                    date = futureDate.ToString("yyyy-MM-dd"),
                    temperatureC = temperatureC,
                    summary = summaries[random.Next(0, summaries.Length)]
                };
            }
            return new OkObjectResult(forecasts);
        }
    }
}


// TOOL GENERATED: func new --language C# --template "Http Trigger" --name WeatherForecast
// using System;
// using System.IO;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Azure.WebJobs;
// using Microsoft.Azure.WebJobs.Extensions.Http;
// using Microsoft.AspNetCore.Http;
// using Microsoft.Extensions.Logging;
// using Newtonsoft.Json;

// namespace Api
// {
//     public static class WeatherForecast
//     {
//         [FunctionName("WeatherForecast")]
//         public static async Task<IActionResult> Run(
//             [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
//             ILogger log)
//         {
//             log.LogInformation("C# HTTP trigger function processed a request.");

//             string name = req.Query["name"];

//             string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
//             dynamic data = JsonConvert.DeserializeObject(requestBody);
//             name = name ?? data?.name;

//             string responseMessage = string.IsNullOrEmpty(name)
//                 ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
//                 : $"Hello, {name}. This HTTP triggered function executed successfully.";

//             return new OkObjectResult(responseMessage);
//         }
//     }
// }
