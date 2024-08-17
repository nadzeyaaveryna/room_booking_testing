using Microsoft.Playwright;

namespace BookingRoom.UI.Pages
{
    public abstract class BasePage
    {
        protected readonly IPage Page;

        public abstract string Url { get; }

        protected BasePage(IPage page)
        {
            Page = page;
        }

        public virtual async Task OpenPage()
        {
            await Page.GotoAsync(Url);
        }
    }
}
