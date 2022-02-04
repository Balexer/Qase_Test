using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Qase_Test.Utils;
using WebDriverManager.DriverConfigs.Impl;

namespace Qase_Test.Core
{
    public class BrowsersService
    {
        private readonly IWebDriver _driver;
        private readonly Waiters _waiters;

        public BrowsersService()
        {
            switch (ReadProperties.Browser.ToLower())
            {
                //DEV_NOTE: I will realise more browsers
                case "chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    _driver = new ChromeDriver(BrowsersOptions.GetChromeOptions());
                    break;
                default:
                    Console.WriteLine($"Browser {ReadProperties.Browser} is not supported");
                    break;
            }

            _waiters = new Waiters(_driver, ReadProperties.Timeout);
        }

        public IWebDriver GetDriver()
        {
            return _driver;
        }

        public Waiters GetWaiters()
        {
            return _waiters;
        }
    }
}
