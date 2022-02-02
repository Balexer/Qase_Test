using Qase_Test.Core;

namespace Qase_Test.BaseEntity
{
    public class BaseStep
    {
        public BrowsersService browsersService;

        public BaseStep(BrowsersService browsersService)
        {
            this.browsersService = browsersService;
        }
    }
}