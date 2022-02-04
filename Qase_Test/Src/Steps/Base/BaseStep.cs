using Qase_Test.Core;

namespace Qase_Test.Steps.Base
{
    public class BaseStep
    {
        protected readonly BrowsersService BrowsersService;

        protected BaseStep(BrowsersService browsersService)
        {
            BrowsersService = browsersService;
        }
    }
}
