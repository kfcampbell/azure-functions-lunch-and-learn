using System;
using System.Collections.Generic;
using System.IO;
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
    public interface ITwilioService
    {
        bool SendSms(string contents, List<string> phoneNumbers);
    }

    public class TwilioService : ITwilioService
    {
        public TwilioService() { }

        public bool SendSms(string contents, List<string> phoneNumbers)
        {
            string accountSid = Environment.GetEnvironmentVariable("TwilioAccountSid");
            string authToken = Environment.GetEnvironmentVariable("TwilioAuthToken");

            TwilioClient.Init(accountSid, authToken);

            foreach (var number in phoneNumbers)
            {
                var message = MessageResource.Create(
                    body: contents,
                    from: new PhoneNumber(Environment.GetEnvironmentVariable("FromPhoneNumber")),
                    to: new PhoneNumber(number));

                Console.WriteLine(message.Sid);
            }
            return true;
        }
    }
}