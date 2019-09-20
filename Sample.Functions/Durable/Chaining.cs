using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Sample.Functions.Durable
{
    public static class Chaining
    {
        [FunctionName("Chaining")]
        public static async Task<List<string>> RunOrchestrator(
            [OrchestrationTrigger] DurableOrchestrationContext context)
        {
            var outputs = new List<string>();

            // Replace "hello" with the name of your Durable Activity Function.
            outputs.Add(await context.CallActivityAsync<string>("Chaining_Hello", "Iron Man"));
            outputs.Add(await context.CallActivityAsync<string>("Chaining_HowAreYou", "Iron Man"));
            outputs.Add(await context.CallActivityAsync<string>("Chaining_Goodbye", "Iron Man"));

            return outputs;
        }

        [FunctionName("Chaining_Hello")]
        public static string SayHello([ActivityTrigger] string name, ILogger log)
        {
            log.LogInformation($"Saying hello to {name}.");
            return $"Hello {name}!";
        }

        [FunctionName("Chaining_Goodbye")]
        public static string SayGoodbye([ActivityTrigger] string name, ILogger log)
        {
            log.LogInformation($"Saying goodbye to {name}.");
            return $"Goodbye {name}!";
        }

        [FunctionName("Chaining_HowAreYou")]
        public static string SayHowAreYou([ActivityTrigger] string name, ILogger log)
        {
            log.LogInformation($"Saying how are you to {name}.");
            return $"How are you, {name}?";
        }

        [FunctionName("DurableIronMan")]
        public static async Task<HttpResponseMessage> HttpStart(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")]HttpRequestMessage req,
            [OrchestrationClient]DurableOrchestrationClient starter,
            ILogger log)
        {
            // Function input comes from the request content.
            string instanceId = await starter.StartNewAsync("Chaining", null);

            log.LogInformation($"Started orchestration with ID = '{instanceId}'.");

            return starter.CreateCheckStatusResponse(req, instanceId);
        }
    }
}