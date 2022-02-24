namespace Qase_Test.Core
{
    public class UserSettings : ReadProperties
    {
        public static string Email => Configuration[nameof(Email)];

        public static string Password => Configuration[nameof(Password)];
    }
}
