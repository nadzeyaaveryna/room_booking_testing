using BookingRoom.Core.Configuration;
using Microsoft.Playwright;

namespace BookingRoom.TAF.Support
{
    public static class ScreenshotHelper
    {
        public const string ScreenshotFullDateTimeFormat = "yyyy-MM-ddTHH-mm-ss";

        /// <summary>
        /// Takes screenshot
        /// </summary>
        /// <param name="page">Playwright page</param>
        /// <param name="testName">test name</param>
        /// <param name="directory">directory</param>
        public static async Task Screenshot(this IPage page, string testName, string directory = null)
        {
            directory ??= Directory.GetCurrentDirectory();

           var timeStamp = DateTime.UtcNow.ToString(ScreenshotFullDateTimeFormat);
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
