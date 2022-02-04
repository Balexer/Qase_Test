using Qase_Test.Core;

namespace Qase_Test.BaseEntity
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
