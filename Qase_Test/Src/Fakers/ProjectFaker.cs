using Bogus;
using Qase_Test.Models;

namespace Qase_Test.Fakers
{
    public static class ProjectFaker
    {
        public static Project GetFakeProject()
        {
            return new Faker<Project>()
                .RuleFor(x => x.ProjectName, f => f.Lorem.Word())
                .RuleFor(x => x.ProjectCode, f => f.Internet.Password())
                .RuleFor(x => x.ProjectDescription, f => f.Lorem.Paragraph())
                .RuleFor(x => x.WrongProjectCode, f => f.Internet.Password(1));
        }
    }
}
