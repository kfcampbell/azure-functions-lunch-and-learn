using Microsoft.VisualStudio.TestTools.UnitTesting;
using HttpTrigger.Pipeline.Results;

namespace tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            http_trigger_pipeline_results.Run(null, null, null);
            Assert.IsTrue(true);
        }
    }
}
