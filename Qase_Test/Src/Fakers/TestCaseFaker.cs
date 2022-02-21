using Bogus;
using Qase_Test.Constants;
using Qase_Test.Models;

namespace Qase_Test.Fakers
{
    public static class TestCaseFaker
    {
        public static TestCase GetFakeCase()
        {
            return new Faker<TestCase>()
                .RuleFor(x => x.CaseTitle, f => f.Lorem.Word())
                .RuleFor(x => x.Description, f => f.Lorem.Paragraph())
                .RuleFor(x => x.Preconditions, f => f.Lorem.Paragraph())
                .RuleFor(x => x.Postconditions, f => f.Lorem.Paragraph())
                .RuleFor(x => x.Severity, f => f.PickRandom(TestCaseConstants.Severity))
                .RuleFor(x => x.Status, f => f.PickRandom(TestCaseConstants.Status))
                .RuleFor(x => x.Priority, f => f.PickRandom(TestCaseConstants.Priority))
                .RuleFor(x => x.Behavior, f => f.PickRandom(TestCaseConstants.Behavior))
                .RuleFor(x => x.Type, f => f.PickRandom(TestCaseConstants.Type))
                .RuleFor(x => x.IsFlaky, f => f.PickRandom(TestCaseConstants.IsFlaky))
                .RuleFor(x => x.Layer, f => f.PickRandom(TestCaseConstants.Layer))
                .RuleFor(x => x.Automation, f => f.PickRandom(TestCaseConstants.Automation));
        }
    }
}
