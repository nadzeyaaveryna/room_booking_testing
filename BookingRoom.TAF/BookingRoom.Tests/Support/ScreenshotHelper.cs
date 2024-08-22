using BookingRoom.Core.Constants;
using Microsoft.Playwright;

namespace BookingRoom.Tests.Support
{
    public static class ScreenshotHelper
    {
        /// <summary>
        /// Takes screenshot
        /// </summary>
        /// <param name="page">Playwright page</param>
        /// <param name="testName">test name</param>
        /// <param name="directory">directory</param>
        public static async Task Screenshot(this IPage page, string testName, string directory)
        {
            directory ??= Directory.GetCurrentDirectory();

           var timeStamp = DateTime.UtcNow.ToString(DateTimeFormats.ScreenshotFullDateTimeFormat);
            var title = await page.TitleAsync();
            var fileName = $"{timeStamp}_{title}-{testName}.png";

            var screenshotOptions = new PageScreenshotOptions()
            {
                Path = Path.Combine(directory, fileName),
                FullPage = true,
            };

            await page.ScreenshotAsync(screenshotOptions);
        }
    }
}
