using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Sample.Functions
{
    public static class Timer
    {
        [FunctionName("TimerSample")]
        public static void Run([TimerTrigger("*/10 * * * * 5")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation("Demo C# Timer triggered every 10 seconds on Fridays");
            log.LogInformation($"Current time: {DateTime.Now}");
        }
    }
}
