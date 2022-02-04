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
        private readonly string _baseUrl;

        public BrowsersService()
        {
            _baseUrl = ReadProperties.Url;

            switch (ReadProperties.Browser.ToLower())
            {
                //DEV_NOTE: I will realise more browsers
                case "chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments("--disable-gpu", "--ignore-certificate-errors", "--silent",
                        "--start-maximized");
                    _driver = new ChromeDriver(chromeOptions);
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
