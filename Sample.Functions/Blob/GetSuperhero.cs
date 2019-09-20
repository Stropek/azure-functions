using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Sample.Functions
{
    public static class GetSuperhero
    {
        [FunctionName("GetSuperhero")]
        public static void Run([BlobTrigger("superheroes/{name}", Connection = "AzureWebJobsStorage")]Stream myBlob, string name, ILogger log)
        {
            log.LogInformation($"New superhero picture uploaded to blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
        }
    }
}
