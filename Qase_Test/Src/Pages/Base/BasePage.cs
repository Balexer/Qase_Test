using System;
using System.Security.Claims;
using OpenQA.Selenium;
using Qase_Test.Core;

namespace Qase_Test.Pages.Base
{
    public abstract class BasePage
    {
        protected readonly BrowsersService BrowsersService;
        private readonly By _locator;

        protected BasePage(BrowsersService browsersService, By locator)
        {
            BrowsersService = browsersService;
            _locator = locator;
        }

        protected bool WaitForOpen()
        {
            try
            {
                return BrowsersService.GetWaiters().WaitForVisibility(_locator).Displayed;
            }
            catch (NoSuchElementException e)
            {
                // Console.WriteLine("error message");
                return false;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}
