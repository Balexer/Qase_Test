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
        private IWebDriver driver = null;
        private Waiters waiters;
        private string baseUrl;

        public BrowsersService()
        {
            baseUrl = ReadProperties.Url;

            switch (ReadProperties.Browser.ToLower())
            {
                case "chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments("--disable-gpu");
                    chromeOptions.AddArguments("--ignore-certificate-errors");
                    chromeOptions.AddArguments("--silent");
                    chromeOptions.AddArguments("--start-maximized");
                    driver = new ChromeDriver(chromeOptions);
                    break;
            }

            waiters = new Waiters(driver, ReadProperties.Timeout);
        }

        public IWebDriver GetDriver()
        {
            return driver;
        }

        public Waiters GetWaiters()
        {
            return waiters;
        }

        public string GetBaseUrl()
        {
            return baseUrl;
        }

        public void sleep(long millis)
        {
            
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(Convert.ToDouble(millis)));
            }
            catch (ThreadInterruptedException)
            {
                Console.WriteLine();
            }
        }
    }
}