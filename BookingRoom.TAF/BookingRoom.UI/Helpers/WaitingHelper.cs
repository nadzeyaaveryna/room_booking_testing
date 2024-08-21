using BookingRoom.UI.Pages.BookPage.Components;
using Microsoft.Playwright;

namespace BookingRoom.UI.Helpers
{
    /// <summary>
    /// TODO: Refactor, use Playwright assertions instead
    /// </summary>
    public static class WaitingHelper
    {

        public static async Task WaitForElement(this ILocator locator, int timeout = 1000)
        {
            try
            {
                await locator.WaitForAsync(new LocatorWaitForOptions()
                {
                    State = WaitForSelectorState.Visible,
                    Timeout = 3000
                });

            }
            catch (TimeoutException ex)
            {
            }
        }
    }
}
