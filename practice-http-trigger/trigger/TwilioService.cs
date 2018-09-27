using Twilio;
using System.Collections.Generic;
using System;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Practice.Http.Trigger
{
    public interface ITwilioService
    {
        bool SendSms(List<string> phoneNumbers, string content);
    }

    public class TwilioService : ITwilioService
    {
        public bool SendSms(List<string> phoneNumbers, string content)
        {
            try
            {
                string accountSid = Environment.GetEnvironmentVariable("TwilioAccountSid");
                string authToken = Environment.GetEnvironmentVariable("TwilioAuthToken");

                TwilioClient.Init(accountSid, authToken);

                foreach (var number in phoneNumbers)
                {
                    var message = MessageResource.Create(
                        body: content,
                        from: new PhoneNumber(Environment.GetEnvironmentVariable("FromPhoneNumber")),
                        to: new PhoneNumber(number));

                    Console.WriteLine(message.Sid);
                }
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}