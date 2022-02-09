using Qase_Test.Core;

namespace Qase_Test.Models
{
    public static class ModelsSettings
    {
        public static User GetUser() =>
            new()
            {
                Email = ReadProperties.Email,
                Password = ReadProperties.Password
            };
    }
}
