using BookingRoom.Core.Configuration;
using Microsoft.Playwright;

namespace BookingRoom.TAF.Drivers
{
    public class Driver
    {
        private readonly Task<IBrowser> _browser;

        public Driver(BrowserType browserType, bool isHeadless)
        {
            _browser = Task.Run(() => CreateBrowser(browserType, isHeadless));
        }

        public IBrowser Browser => _browser.Result;

        public async Task<IPlaywright> CreatePlaywright() => await Playwright.CreateAsync();

        public BrowserTypeLaunchOptions SetUpLaunchOptions(bool isHeadless) =>
            new()
            {
                Headless = isHeadless,
                Args = new List<string> { DriverArgs.MaximizedParamName }
            };

        public async Task<IBrowser> CreateBrowser(BrowserType browserType, bool isHeadless)
        {
            var playwright = await CreatePlaywright();
            var browserTypeLaunchOptions = SetUpLaunchOptions(isHeadless);

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
