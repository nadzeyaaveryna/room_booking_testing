using Microsoft.Playwright;

namespace BookingRoom.UI.Drivers
{
    /// <summary>
    /// Create instance of browser with particular type 
    /// </summary>
    public static class BrowserFactory
    {
        public static async Task<IBrowser> CreateChromiumBrowser(this IPlaywright playwright, BrowserTypeLaunchOptions options)
        {
            return await playwright.Chromium.LaunchAsync(options);
        }

        public static async Task<IBrowser> CreateFirefoxBrowser(this IPlaywright playwright, BrowserTypeLaunchOptions options)
        {
            return await playwright.Firefox.LaunchAsync(options);
        }

        public static async Task<IBrowser> CreateSafariBrowser(this IPlaywright playwright, BrowserTypeLaunchOptions options)
        {
            return await playwright.Webkit.LaunchAsync(options);
        }
    }
}
