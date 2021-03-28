using Microsoft.VisualStudio.TestTools.UnitTesting;
using QACoreTests;
using ClientOneDesktopTests.PageObjects;
using an = QaCore.ActionNames;

namespace ClientOneDesktopTests
{
    [TestClass]
    public class DemoTests : BaseTest
    {
        [TestMethod]
        public void UltimateQaSearch()
        {
            Navigate(@"https://ultimateqa.com/fake-landing-page");
            Assert.IsTrue(IsTitle("Fake landing page - Ultimate QA"));
            DoIt(FakeLandingPage.link_Courses, an.Click);
            DoIt(Courses.input_Search, an.WaitUntilVisible);
        }
    }
}