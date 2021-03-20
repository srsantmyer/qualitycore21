using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Models;

namespace QaCore
{
    public class WebDriverUtil
    {
        /// <summary>
        /// Return a webdriver object
        /// </summary>
        /// <param name="driverType"></param>
        /// <returns></returns>
        public IWebDriver GetWebDriver(DriverType driverType)
        {
            IWebDriver driver = null;
            switch (driverType)
            {
                case DriverType.Chrome:
                    driver = new ChromeDriver();
                    break;
                case DriverType.Firefox:
                    driver = new FirefoxDriver();
                    break;
            }
            return driver;
        }

    }
}
