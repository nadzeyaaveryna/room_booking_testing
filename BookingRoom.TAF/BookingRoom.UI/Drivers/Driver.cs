using Microsoft.Playwright;

namespace BookingRoom.UI.Drivers
{
    public class Driver
    {
        private readonly Task<IPlaywright> _playwright;
        private readonly Task<IBrowser> _browser;
        private readonly Task<IBrowserContext> _browserContext;

        public Driver(BrowserType browserType, bool isHeadless)
        {
            _playwright =  Task.Run(CreatePlaywright);
            _browser = Task.Run(() => CreateBrowser(browserType, isHeadless));
            _browserContext = Task.Run(CreateBrowserContext);
        }

        public IPlaywright PlaywrightInstance => _playwright.Result;

        public IBrowser Browser => _browser.Result;

        public IBrowserContext BrowserContext => _browserContext.Result;

        public async Task<IPlaywright> CreatePlaywright() => await Playwright.CreateAsync();

        public BrowserTypeLaunchOptions SetUpLaunchOptions(bool isHeadless) =>
            new()
            {
                Headless = isHeadless,
                Args = new [] { DriverArgs.MaximizedParamName },
                
            };

        public async Task<IBrowser> CreateBrowser(BrowserType browserType, bool isHeadless)
        {
            var browserTypeLaunchOptions = SetUpLaunchOptions(isHeadless);

            return await (browserType switch
            {
                BrowserType.Chrome => _playwright.Result.CreateChromiumBrowser(browserTypeLaunchOptions),
                BrowserType.Firefox => _playwright.Result.CreateFirefoxBrowser(browserTypeLaunchOptions),
                BrowserType.Safari => _playwright.Result.CreateSafariBrowser(browserTypeLaunchOptions),
                _ => throw new ArgumentOutOfRangeException(nameof(browserType), browserTypeLaunchOptions, null)
            });
        }

        public async Task<IBrowserContext> CreateBrowserContext() =>
            await Browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = ViewportSize.NoViewport
            });
    }
}
