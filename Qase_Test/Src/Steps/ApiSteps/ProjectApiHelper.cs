using System.Net;
using NUnit.Allure.Attributes;
using Qase_Test.Core;
using Qase_Test.Models;
using Qase_Test.Steps.ApiSteps.Base;
using Qase_Test.Utils;
using RestSharp;

namespace Qase_Test.Steps.ApiSteps
{
    public class ProjectApiHelper : BaseApiHelper
    {
        private const string BaseUrl = "https://api.qase.io/v1/project";

        [AllureStep("Try to create project")]
        public static HttpStatusCode CreateProject(Project project, string token = null)
        {
            var parameters =
                $"{{\"title\":\"{project.ProjectName}\",\"code\":\"{project.ProjectCode}\",\"description\":\"{project.ProjectDescription}\"}}";
            return Client(BaseUrl)
                .Execute(BaseRequest(Method.POST, token ?? UserSettings.Token, parameters)).StatusCode;
        }

        [AllureStep("Try to delete project")]
        public static HttpStatusCode DeleteProject(Project project, string token = null) =>
            Client($"{BaseUrl}/{project.ProjectCode}")
                .Execute(BaseRequest(Method.DELETE, token ?? UserSettings.Token)).StatusCode;
    }
}
