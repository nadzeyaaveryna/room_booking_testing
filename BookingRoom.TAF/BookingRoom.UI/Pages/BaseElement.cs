using BookingRoom.UI.Pages.BookPage.Components;
using Microsoft.Playwright;

namespace BookingRoom.UI.Pages
{
    public abstract class BaseElement
    {
        protected readonly IPage _page;
        protected readonly ILocator _rootElement;

        protected BaseElement(ILocator rootElement, IPage page)
        {
            _page = page;
            _rootElement = rootElement;
        }

        public async Task<bool> IsElementDisplayed()
        {
            try
            {
                await _rootElement.WaitForAsync(new LocatorWaitForOptions()
                {
                    State = WaitForSelectorState.Visible,
                    Timeout = 500
                });

            }
            catch (TimeoutException ex)
            {
            }


            return await _rootElement.IsVisibleAsync();
        }
    }
}
