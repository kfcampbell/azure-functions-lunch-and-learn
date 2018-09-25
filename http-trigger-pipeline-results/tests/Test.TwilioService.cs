using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using Moq;
using HttpTrigger.Pipeline.Results;

namespace tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task RunFunction_SmsSucceeds_ReturnsTrue()
        {
            // arrange
            var twilioService = new Mock<ITwilioService>();
            twilioService.Setup(t => t.SendSms(It.IsAny<string>(), It.IsAny<List<string>>())).Returns(true);

            // act
            var result = (OkObjectResult) await http_trigger_pipeline_results.Run(null, null, twilioService.Object);

            // assert
            Assert.IsTrue(result.StatusCode == 200);
        }

        [TestMethod]
        public async Task RunFunction_SmsFailed_ReturnsFalse()
        {
            // arrange
            var twilioService = new Mock<ITwilioService>();
            twilioService.Setup(t => t.SendSms(It.IsAny<string>(), It.IsAny<List<string>>())).Returns(false);

            // act
            var result = (BadRequestObjectResult) await http_trigger_pipeline_results.Run(null, null, twilioService.Object);

            // assert
            Assert.IsTrue(result.StatusCode == 400);
        }
    }
}
