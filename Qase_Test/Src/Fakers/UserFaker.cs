using Bogus;
using Qase_Test.Models;

namespace Qase_Test.Fakers
{
    public static class UserFaker
    {
        public static User GetFakeUser()
        {
            return new Faker<User>()
                .RuleFor(x => x.Email, f => f.Internet.Email())
                .RuleFor(x => x.Password, f => f.Internet.Password());
        }
    }
}
