using System.Collections.Generic;

namespace Qase_Test.Constants
{
    public static class TestCaseConstants
    {
        public const string DescriptionProperty = "Description";
        public const string PreconditionsProperty = "Pre-conditions";
        public const string PostconditionsProperty = "Post-conditions";
        public const string SeverityProperty = "Severity";
        public const string StatusProperty = "Status";
        public const string PriorityProperty = "Priority";
        public const string BehaviorProperty = "Behavior";
        public const string TypeProperty = "Type";
        public const string IsFlakyProperty = "Is Flaky";
        public const string LayerProperty = "Layer";
        public const string AutomationProperty = "Automation status";

        public static readonly List<string> Severity = new()
            {"Blocker", "Critical", "Major", "Normal", "Minor", "Trivial"};
        public static readonly List<string> Status = new() {"Actual", "Draft", "Deprecated"};
        public static readonly List<string> Priority = new() {"Not set", "High", "Medium", "Low"};
        public static readonly List<string> Behavior = new() {"Not set", "Positive", "Negative", "Destructive"};
        public static readonly List<string> Type = new()
        {
            "Other", "Functional", "Smoke", "Regression", "Security", "Usability", "Performance", "Acceptance",
            "Compatibility", "Integration", "Exploratory"
        };
        public static readonly List<string> IsFlaky = new() {"No", "Yes"};
        public static readonly List<string> Layer = new() {"Unknown", "E2E", "API", "Unit"};
        public static readonly List<string> Automation = new() {"Not automated", "To be automated", "Automated"};
        
    }
}
