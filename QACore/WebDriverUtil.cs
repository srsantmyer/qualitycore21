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
        public IWebDriver GetWebDriver(DriverType driverType, bool headless)
        {
            IWebDriver driver = null;
            switch (driverType)
            {
                case DriverType.Chrome:
                    var opts = new ChromeOptions();
                    //opts.AddArgument("--start-maximized");
                    opts.AddArgument("--window-size=1920,1080");
                    opts.AddArgument("−−incognito");

                    if (headless)
                    {
                        if (!System.Diagnostics.Debugger.IsAttached)
                        {
                            opts.AddArgument("--headless");
                        }
                    }
                    driver = new ChromeDriver(opts);
                    break;
                case DriverType.Firefox:
                    driver = new FirefoxDriver();
                    break;
            }
            return driver;
        }

    }
}
