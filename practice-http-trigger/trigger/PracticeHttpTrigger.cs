using System.Collections.Generic;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using AzureFunctions.Autofac;

namespace Practice.Http.Trigger
{
    [DependencyInjectionConfig(typeof(DIConfig))]
    public static class PracticeHttpTrigger
    {
        [FunctionName("PracticeHttpTrigger")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequest req, 
            ILogger log, [Inject] ITwilioService twilioService)
        {
            if(log != null)
            {
                log.LogInformation("C# HTTP trigger function processed a request.");
            }

            var sendSmsResult = twilioService.SendSms(
                new List<string> {
                    Environment.GetEnvironmentVariable("ToPhoneNumber")
                },
                "Check the oven. Your build is done!"
            );

            if(sendSmsResult)
            {
                return (ActionResult)new OkObjectResult($"Aww yeahhh...it worked, yo.");
            }
            else
            {
                return new BadRequestObjectResult("You done fucked up!");
            }
        }
    }
}
