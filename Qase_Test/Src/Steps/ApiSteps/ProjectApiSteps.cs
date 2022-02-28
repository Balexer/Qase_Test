using System.Net;
using NUnit.Allure.Attributes;
using Qase_Test.Models;
using Qase_Test.Steps.ApiSteps.Base;
using RestSharp;

namespace Qase_Test.Steps.ApiSteps
{
    public class ProjectApiSteps : BaseApiStep
    {
        private const string BaseUrl = "https://api.qase.io/v1/project";

        [AllureStep("Try to create project")]
        public static HttpStatusCode CreateProject(Project project, string token)
        {
            var parameters =
                $"{{\"title\":\"{project.ProjectName}\",\"code\":\"{project.ProjectCode}\",\"description\":\"{project.ProjectDescription}\"}}";
            return Client(BaseUrl)
                .Execute(BaseRequest(Method.POST, token, parameters)).StatusCode;
        }

        [AllureStep("Try to delete project")]
        public static HttpStatusCode DeleteProject(Project project, string token) =>
            Client($"{BaseUrl}/{project.ProjectCode}")
                .Execute(BaseRequest(Method.DELETE, token)).StatusCode;
    }
}
