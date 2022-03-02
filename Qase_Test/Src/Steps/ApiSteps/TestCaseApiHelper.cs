using System.Net;
using Newtonsoft.Json.Linq;
using NUnit.Allure.Attributes;
using Qase_Test.Core;
using Qase_Test.Models;
using Qase_Test.Steps.ApiSteps.Base;
using RestSharp;

namespace Qase_Test.Steps.ApiSteps
{
    public class TestCaseApiHelper : BaseApiHelper
    {
        private const string BaseUrl = "https://api.qase.io/v1/case";

        [AllureStep("Try to create test case")]
        public static HttpStatusCode CreateTestCase(Project project, TestCase testCase, string token = null)
        {
            var parameters = $"{{\"title\":\"{testCase.CaseTitle}\"}}";
            return Client($"{BaseUrl}/{project.ProjectCode}")
                .Execute(BaseRequest(Method.POST, token ?? UserSettings.Token, parameters)).StatusCode;
        }

        [AllureStep("Try to delete test case")]
        public static HttpStatusCode DeleteTestCase(Project project, string token = null) =>
            Client($"{BaseUrl}/{project.ProjectCode}/1")
                .Execute(BaseRequest(Method.DELETE, token ?? UserSettings.Token)).StatusCode;

        [AllureStep("Get title from test case")]
        public static string GetTestCaseTitle(Project project, string token = null)
        {
            dynamic r = JObject.Parse(Client($"{BaseUrl}/{project.ProjectCode}/1")
                .Execute(BaseRequest(Method.GET, token ?? UserSettings.Token)).Content);
            return r.result.title;
        }
    }
}
