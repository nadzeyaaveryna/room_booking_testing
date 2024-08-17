using Microsoft.Playwright;

namespace BookingRoom.UI.Pages.BookPage
{
    public class BookPage : BasePage
    {
        public override string Url => "https://automationintesting.online/";
        public BookPage(IPage page) : base(page)
        {
        }

        private ILocator BookButton => Page.Locator(".openBooking");

 

        public override async Task OpenPage()
        {
            await Page.GotoAsync(Url);
            await Page.AddStyleTagAsync(new() { Content = "#collapseBanner { display: none !important; }" });
        }

        public async Task ClickBookThisRoomButton() => await BookButton.ClickAsync();
    }
}
