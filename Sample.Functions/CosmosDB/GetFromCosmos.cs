using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Sample.Functions.Models;

namespace Sample.Functions.CosmosDB
{
    public static class GetFromCosmos
    {
        [FunctionName("GetFromCosmos")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req,
            [CosmosDB(
                databaseName: "marvel",
                collectionName: "superheroes",
                ConnectionStringSetting = "AzureCosmosDb",
                Id = "{Query.id}")] Superhero superhero,
            ILogger log)
        {
            log.LogInformation("Getting superhero from cosmos DB");

            return new OkObjectResult(superhero);
        }
    }
}
