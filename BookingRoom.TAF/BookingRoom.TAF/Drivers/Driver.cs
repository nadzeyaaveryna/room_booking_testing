using BookingRoom.Core.Configuration;
using Microsoft.Playwright;
using System.Threading.Tasks;

namespace BookingRoom.TAF.Drivers
{
    public class Driver
    {
        private readonly Task<IBrowser> _browser;

        public Driver(BrowserType browserType)
        {
            _browser = Task.Run(() => CreateBrowser(browserType));
        }

        public IBrowser Browser => _browser.Result;

        public async Task<IPlaywright> CreatePlaywright() => await Playwright.CreateAsync();

        public BrowserTypeLaunchOptions SetUpLaunchOptions() =>
            new()
            {
                Headless = AppConfiguration.TestSettings?.IsHeadless,
                Args = new List<string> { DriverArgs.MaximizedParamName }
            };

        public async Task<IBrowser> CreateBrowser(BrowserType browserType)
        {
            var playwright = await CreatePlaywright();
            var browserTypeLaunchOptions = SetUpLaunchOptions();

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
