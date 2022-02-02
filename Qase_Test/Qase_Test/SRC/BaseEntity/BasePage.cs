using NUnit.Framework;
using Qase_Test.Core;

namespace Qase_Test.BaseEntity
{
    public abstract class BasePage
    {
        protected static readonly int WAIT_FOR_PAGE_LOAD_IN_SECONDS = 5;
        protected readonly BrowsersService BrowsersService;

        public abstract bool IsPageOpened();

        public BasePage(BrowsersService browsersService)
        {
            this.BrowsersService = browsersService;
            WaitForOpen();
        }

        protected void WaitForOpen()
        {
            var secondCount = 0;
            var isPageOpenedIndicator = IsPageOpened();
            while (!isPageOpenedIndicator && secondCount < WAIT_FOR_PAGE_LOAD_IN_SECONDS)
            {
                BrowsersService.sleep(1000);
                secondCount++;
                isPageOpenedIndicator = IsPageOpened();
            }

            if (!isPageOpenedIndicator)
            {
                throw new AssertionException("Page was not opened");
            }
        }
    }
}