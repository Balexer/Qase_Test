using NUnit.Allure.Attributes;
using Qase_Test.Constants;
using RestSharp;

namespace Qase_Test.Steps.ApiSteps.Base
{
    public class BaseApiStep
    {
        [AllureStep("Authorization")]
        protected static IRestRequest BaseRequest(Method method, string token, string parameters)
        {
            return AddHeaders(method, token)
                .AddParameter(ContentTypes.ApplicationJson, parameters, ParameterType.RequestBody);
        }

        [AllureStep("Authorization")]
        protected static IRestRequest BaseRequest(Method method, string token)
        {
            return AddHeaders(method, token);
        }

        private static IRestRequest AddHeaders(Method method, string token)
        {
            var request = new RestRequest(method);
            request.AddHeader("Accept", ContentTypes.ApplicationJson);
            request.AddHeader("Content-Type", ContentTypes.ApplicationJson);
            request.AddHeader("Token", token);
            return request;
        }

        protected static RestClient Client(string baseUrl)
        {
            return new RestClient(baseUrl);
        }
    }
}
