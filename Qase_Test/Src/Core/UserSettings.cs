using Qase_Test.Utils;

namespace Qase_Test.Core
{
    public class UserSettings
    {
        public static string Email => ReadProperties.Configuration[nameof(Email)];

        public static string Password => ReadProperties.Configuration[nameof(Password)];

        public static string Token => ReadProperties.Configuration[nameof(Token)];

        public static string MemberToken => ReadProperties.Configuration[nameof(MemberToken)];
    }
}
