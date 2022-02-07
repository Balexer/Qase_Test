using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Qase_Test.Core.Browser;
using Qase_Test.Utils;

namespace Qase_Test.Core
{
    public class BrowsersService
    {
        private IWebDriver _driver;
        private Waiters _waiters;
        private const string Chrome = "chrome";
        
        

        public void SetupBrowser()
        {
            switch (ReadProperties.Browser.ToLower())
            {
                //DEV_NOTE: I will realise more browsers
                case Chrome:
                    _driver = new ChromeDriver(GetBrowserOptions.GetChromeOptions());
                    break;
                default:
                    Console.WriteLine($"Browser {ReadProperties.Browser} is not supported");
                    break;
            }
        }

        public void SetupWaiters() =>
            _waiters = new Waiters(_driver, ReadProperties.Timeout);
        
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
