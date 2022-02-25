using Qase_Test.Utils;

namespace Qase_Test.Core
{
    public class UserSettings
    {
        public static string Email => ReadProperties.Configuration[nameof(Email)];

        public static string Password => ReadProperties.Configuration[nameof(Password)];
    }
}
