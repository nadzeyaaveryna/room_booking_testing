using Microsoft.Playwright;
using System.Threading.Tasks;

namespace BookingRoom.TAF.Drivers
{
    public class Driver
    {
        public Driver() { }

        public Driver(BrowserType browserType, BrowserTypeLaunchOptions browserTypeLaunchOptions)
        {
            _browser = Task.Run(() => CreateBrowser(browserType, browserTypeLaunchOptions));
        }

        private readonly Task<IBrowser> _browser;

        public IBrowser Browser => _browser.Result;

        public async Task<IPlaywright> CreatePlaywright()
        {
           return await Playwright.CreateAsync();
        }

        public async Task<IBrowser> CreateBrowser(BrowserType browserType, BrowserTypeLaunchOptions browserTypeLaunchOptions)
        {
            //var browserTypeLaunchOptions = new BrowserTypeLaunchOptions
            //{
            //    Headless = false,
            //};

            var playwright = await CreatePlaywright();
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
