using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using QaCore;

namespace QACoreTests
{
    [TestClass]
    public class UnitTest1 : BaseTest
    {
        [TestMethod]
        public void ProcessRowTest()
        {
            Navigate("https://google.com");
            var x = IsTitle("Google");
            Assert.IsTrue(x);
        }
    }
}
