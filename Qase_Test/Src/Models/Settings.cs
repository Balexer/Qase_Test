using Qase_Test.Core;

namespace Qase_Test.Models
{
    public static class Settings
    {
        public static User GetUser() =>
            new()
            {
                Email = ReadProperties.Email,
                Password = ReadProperties.Password
            };
    }
}
