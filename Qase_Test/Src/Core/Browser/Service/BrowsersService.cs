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

        public static IWebDriver GetDriver { get; private set; }

        public static Waiters GetWaiters { get; private set; }

        public static void SetupBrowser()
        {
            switch (ReadProperties.Browser.ToLower())
            {
                //DEV_NOTE: I will realise more browsers (FireFox)
                case Chrome:
                    GetDriver = new ChromeDriver(GetBrowserOptions.GetChromeOptions());
                    break;
                default:
                    Logger.Error($"Browser {ReadProperties.Browser} is not supported");
                    break;
            }
        }

        public static void SetupWaiters() =>
            GetWaiters = new Waiters(GetDriver, ReadProperties.Timeout);
    }
}
