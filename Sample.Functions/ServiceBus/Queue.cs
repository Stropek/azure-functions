using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Sample.Functions
{
    public static class Queue
    {
        [FunctionName("Queue")]
        public static void Run([ServiceBusTrigger("superheroes", Connection = "AzureServiceBus")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"Superhero added to the queue: {myQueueItem}");
        }
    }
}
