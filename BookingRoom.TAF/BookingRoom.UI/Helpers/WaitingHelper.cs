using BookingRoom.Core.Utils.Logger;
using Microsoft.Playwright;

namespace BookingRoom.UI.Helpers
{
    /// <summary>
    /// Provides methods for elements waiting
    /// TODO: Refactor, use Playwright assertions instead
    /// </summary>
    public static class WaitingHelper
    {
        private static ILogger Logger => LoggerInstance.Instance(typeof(WaitingHelper));

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
            catch (Exception ex) when(ex is TimeoutException || ex is PlaywrightException)
            {
                Logger.Error($"Exception {ex} has been thrown.");
            }
        }
    }
}
