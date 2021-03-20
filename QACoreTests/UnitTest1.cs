using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using QaCore;

namespace QACoreTests
{
    [TestClass]
    public class UnitTest1
    {
        Runner runner = new Runner(new RunnerArguments()
        {
            DriverType = DriverType.Chrome,
            FileName = "",
            SheetName = "",
            Source = DatasourceType.Excel
        });


        [TestMethod]
        public void ProcessRowTest()
        {
            bool r = false;
            var x = runner.ProcessRow(CreateNavigateStep());
            if (x != null)
            {
                runner.CloseDriver();
                r = true;
            }
            Assert.IsTrue(r);
        }


        private Models.TestStep CreateNavigateStep()
        {
            Models.TestStep t = new Models.TestStep()
            {
                Action = "navigate",
                ActionValue = "https://google.com"
            };
            return t;
        }
    }
}
