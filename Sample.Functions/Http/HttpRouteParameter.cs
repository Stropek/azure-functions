using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace Sample.Functions.Http
{
    public static class HttpRouteParameter
    {
        [FunctionName("HttpRouteParameter")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "parameter/{id}")] HttpRequest req,
            string id,
            ILogger log)
        {
            var message = $"Just passing a parameter in route => id: {id}";

            log.LogInformation(message);

            return new OkObjectResult(message);
        }
    }
}
