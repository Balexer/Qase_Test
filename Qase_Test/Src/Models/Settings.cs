using Qase_Test.Core;

namespace Qase_Test.Models
{
    public class Settings
    {
        public static User GetUser() =>
            new()
            {
                Email = ReadProperties.Email,
                Password = ReadProperties.Password
            };
    }
}
