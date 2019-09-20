using System;
using System.Collections.Generic;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Sample.Functions.Models;

namespace Sample.Functions.CosmosDB
{
    public static class CosmosTrigger
    {
        [FunctionName("CosmosTrigger")]
        public static void Run([CosmosDBTrigger(
            databaseName: "marvel",
            collectionName: "superheroes",
            ConnectionStringSetting = "AzureCosmosDb",
            LeaseCollectionName = "leases",
            CreateLeaseCollectionIfNotExists = true)] IReadOnlyList<Document> superheroes, ILogger log)
        {
            if (superheroes != null && superheroes.Count > 0)
            {
                log.LogInformation("Superheroes modified " + superheroes.Count);
            }
        }
    }
}
