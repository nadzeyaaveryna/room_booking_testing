using Microsoft.Playwright;

namespace BookingRoom.TAF.Drivers
{
    public class Driver
    {
        public async Task<IBrowser> CreateBrowser(BrowserType browserType, BrowserTypeLaunchOptions browserTypeLaunchOptions)
        {
            //var browserTypeLaunchOptions = new BrowserTypeLaunchOptions
            //{
            //    Headless = false,
            //};

            var playwright = await Playwright.CreateAsync();
            return await (browserType switch
            {
                BrowserType.Chrome => playwright.CreateChromiumBrowser(browserTypeLaunchOptions),
                BrowserType.Firefox => playwright.CreateFirefoxBrowser(browserTypeLaunchOptions),
                BrowserType.Safari => playwright.CreateSafariBrowser(browserTypeLaunchOptions),
                _ => throw new ArgumentOutOfRangeException(nameof(browserType), browserTypeLaunchOptions, null)
            });
        }
    }
}
