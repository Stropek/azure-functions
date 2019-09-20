using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace Sample.Functions.Http
{
    public class Superhero
    {
        public string Name { get; set; }

        public string Team { get; set; }
    }

    public static class HttpParameter
    {
        [FunctionName("HttpParameter")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "/parameter/{id}")] Superhero superhero,
            ILogger log)
        {
            var message = $"Superhero name: {superhero.Name} [team: {superhero.Team}]";

            log.LogInformation(message);

            return new OkObjectResult(message);
        }
    }
}
