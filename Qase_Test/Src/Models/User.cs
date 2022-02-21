using Qase_Test.Core;

namespace Qase_Test.Models
{
    public class User
    {
        public string Email { get; set; } = ReadProperties.Email;

        public string Password { get; set; } = ReadProperties.Password;
    }
}
