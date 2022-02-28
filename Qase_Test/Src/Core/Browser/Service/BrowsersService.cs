using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Qase_Test.Utils;

namespace Qase_Test.Core.Browser.Service
{
    public static class BrowsersService
    {
        private const string Chrome = "chrome";
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public static IWebDriver Driver { get; set; }

        public static Waiters Waiters => new(Driver, BrowserSettings.Timeout);

        public static void SetupBrowser()
        {
            switch (BrowserSettings.Browser.ToLower())
            {
                //DEV_NOTE: I will realise more browsers (FireFox)
                case Chrome:
                    Driver ??= new ChromeDriver(GetChromeOptions());
                    break;
                default:
                    Logger.Error($"Browser {BrowserSettings.Browser} is not supported");
                    break;
            }
        }

        private static ChromeOptions GetChromeOptions()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--disable-gpu", "--ignore-certificate-errors", "--silent",
                "--start-maximized");
            return chromeOptions;
        }
    }
}
