using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.Net.Http;
using AzureFunctions.Autofac;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace HttpTrigger.Pipeline.Results
{
    [DependencyInjectionConfig(typeof(DIConfig))]
    public static class http_trigger_pipeline_results
    {
        [FunctionName("http_trigger_pipeline_results")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequest req,
         ILogger log, [Inject] ITwilioService twilioService)
        {
            if(log != null)
            {
                log.LogInformation("C# HTTP trigger function processed a request.");
            }

            var success = twilioService.SendSms("Check the oven. Your build is done!", new List<string> { Environment.GetEnvironmentVariable("ToPhoneNumber") });

            if(success)
            {
                return (ActionResult)new OkObjectResult("Sms sent successfully.");
                //return Ok("Sms sent successfully");
            }
            else
            {
                return (ActionResult)new BadRequestObjectResult("Sms failed! You messed up!");
                //return NotFound("Sms not sent correctly");
            }
        }
    }
}
