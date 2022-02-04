using OpenQA.Selenium.Chrome;

namespace Qase_Test.Utils
{
    public static class BrowsersOptions
    {
        public static ChromeOptions GetChromeOptions()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--disable-gpu", "--ignore-certificate-errors", "--silent",
                "--start-maximized");
            return chromeOptions;
        }
    }
}
