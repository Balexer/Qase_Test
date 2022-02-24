using System;

namespace Qase_Test.Core.Browser
{
    public class BrowserSettings : ReadProperties
    {
        public static string Url => Configuration[nameof(Url)];

        public static string Browser => Configuration[nameof(Browser)];

        public static TimeSpan Timeout => TimeSpan.FromSeconds(Convert.ToDouble(Configuration[nameof(Timeout)]));
    }
}
