﻿using BoDi;
using BookingRoom.Core.Configuration;
using BookingRoom.Core.Utils;
using BookingRoom.Tests.Support;
using BookingRoom.UI.Drivers;
using Microsoft.Playwright;
using NUnit.Framework;
using TechTalk.SpecFlow.Tracing;
using BrowserType = BookingRoom.UI.Drivers.BrowserType;

[assembly: Parallelizable(ParallelScope.Fixtures)]

namespace BookingRoom.Tests.Hooks
{
    [Binding]
    public class Hooks
    {
        public IPlaywright Playwright;
        public IBrowser Browser;
        public IBrowserContext Context;
        public IPage Page;
        public IAPIRequestContext RequestContext;

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
            var isHeadless = AppConfiguration.TestSettings?.IsHeadless;

            var driver = new Driver(browserType.Value, isHeadless.Value);

            Playwright = driver.PlaywrightInstance;
            Browser = driver.Browser;
            Context = driver.BrowserContext;
            RequestContext = await driver.PlaywrightInstance.APIRequest.NewContextAsync();

            Page = await Context.NewPageAsync();

            _objectContainer.RegisterInstanceAs(Page);
            _objectContainer.RegisterInstanceAs(RequestContext);
        }


        [AfterScenario()]
        public async Task CloseBrowser()
        {
            if (_scenarioContext.TestError != null)
            {
                await Page.Screenshot(_scenarioContext.ScenarioInfo.Title.ToIdentifier(), AppConfiguration.TestDataFilesFolder);
            }

            await Browser.DisposeAsync();
        }
    }
}
