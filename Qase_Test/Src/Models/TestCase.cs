namespace Qase_Test.Models
{
    public class TestCase
    {
        public string CaseTitle { get; set; } = "Default";

        public string Description { get; set; } = "Description";

        public string Preconditions { get; set; } = "Preconditions";

        public string Postconditions { get; set; } = "Postconditions";

        public string Severity { get; set; } = "Normal";

        public string Status { get; set; } = "Actual";

        public string Priority { get; set; } = "Not set";

        public string Behavior { get; set; } = "Not set";

        public string Type { get; set; } = "Other";

        public string IsFlaky { get; set; } = "No";

        public string Layer { get; set; } = "Unknown";

        public string Automation { get; set; } = "Not automated";
    }
}
