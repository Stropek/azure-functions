using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Sample.Functions.Models;

namespace Sample.Functions.Http
{
    public static class HttpObject
    {
        [FunctionName("HttpObject")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")] Superhero superhero,
            ILogger log)
        {
            var message = $"Superhero name: {superhero.Name} [team: {superhero.Team}]";

            log.LogInformation(message);

            return new OkObjectResult(message);
        }
    }
}
