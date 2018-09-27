using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Practice.Http.Trigger;
using System.Collections.Generic;

namespace tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SendSms_SuccessfulSms_ShouldReturnSuccess()
        {
            // arrange
            Mock<ITwilioService> twilioService = new Mock<ITwilioService>();
            twilioService.Setup(s => s.SendSms(It.IsAny<List<string>>(), It.IsAny<string>())).Returns(true);

            // act
            var result = (OkObjectResult) PracticeHttpTrigger.Run(null, null, twilioService.Object).Result;

            // assert
            Assert.IsTrue(result.StatusCode == 200);
        }

        [TestMethod]
        public void SendSms_FailedSms_ShouldReturnFailure()
        {
            // arrange
            Mock<ITwilioService> twilioService = new Mock<ITwilioService>();
            twilioService.Setup(s => s.SendSms(It.IsAny<List<string>>(), It.IsAny<string>())).Returns(false);

            // act
            var result = (BadRequestObjectResult) PracticeHttpTrigger.Run(null, null, twilioService.Object).Result;

            // assert
            Assert.IsTrue(result.StatusCode == 400);
        }
    }
}
