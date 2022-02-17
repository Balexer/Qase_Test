using Qase_Test.Core;

namespace Qase_Test.Models
{
    public class User
    {
        public string Email { get; } = ReadProperties.Email;

        public string Password { get; } = ReadProperties.Password;
    }
}
