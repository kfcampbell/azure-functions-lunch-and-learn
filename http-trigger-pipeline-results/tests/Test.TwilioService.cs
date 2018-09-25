using System;
using HttpTrigger.Pipeline.Results;
using Xunit;
using Moq;
using System.Collections.Generic;

namespace tests
{
    public class TwilioServiceTests
    {
        [Fact]
        public void Test1()
        {
            // arrange
            var twilioService = new Mock<ITwilioService>();
            twilioService.Setup(t => t.SendSms(It.IsAny<string>(), It.IsAny<List<string>>())).Returns(false);
            //var logger = new Mock<ILogger>();
            //logger.Setup(l => l.logInformation)

            // act
            http_trigger_pipeline_results.Run(null, null, twilioService.Object);
        }
    }
}
