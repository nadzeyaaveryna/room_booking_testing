using BoDi;
using BookingRoom.Core.Configuration;
using BookingRoom.Core.Utils;
using BookingRoom.TAF.Drivers;
using Microsoft.Playwright;
using BrowserType = BookingRoom.TAF.Drivers.BrowserType;

namespace BookingRoom.TAF.Hooks
{
    [Binding]
    public class Hooks
    {
        public IBrowser browser;
        public IBrowserContext context;
        public IPage page;
        //public IPlaywright playwright;
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        public Hooks(IObjectContainer objectContainer, ScenarioContext scenarioContext)
        {
            _objectContainer = objectContainer;
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static Task BeforeAll()
        {
            AppConfiguration.TestSettings = new ConfigurationSetup().GetAppSettings();
            return Task.CompletedTask;
        }


        [BeforeScenario()]
        public async Task CreateBrowser()
        {
            var browserType = AppConfiguration.TestSettings?.BrowserType.ToEnum<BrowserType>();

            browser = new Driver(browserType.Value).Browser;
            context = await browser.NewContextAsync();
            page = await context.NewPageAsync();
            _objectContainer.RegisterInstanceAs(page);
        }
    }
}
