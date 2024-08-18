using BookingRoom.Core.Configuration;
using BookingRoom.UI.Pages.BookPage.Components;
using Microsoft.Playwright;

namespace BookingRoom.UI.Pages.BookPage
{
    public class BookPage : BasePage
    {
        public override string Url => AppConfiguration.TestSettings.ApplicationUrl;

        public BookPage(IPage page) : base(page)
        {
        }

        private ILocator BookButton => Page.Locator(".openBooking");

        public override async Task OpenPage()
        {
            await Page.GotoAsync(Url);
            await Page.AddStyleTagAsync(new() { Content = "#collapseBanner { display: none !important; }" });
            await Page.WaitForLoadStateAsync();
            await Page.WaitForLoadStateAsync(LoadState.Load);
            await Page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
        }


        public async Task<List<RoomElement>> GetRoomsList()
        {
            //await Page.WaitForSelectorAsync("//*[@class='row room-header']/following-sibling::div", new() {Timeout = 6});
            var roomsElement = Page.Locator("xpath=//*[@class = 'row hotel-room-info']").AllAsync();


            var roomPageElements = new List<RoomElement>();
            foreach (var element in roomsElement.Result)
            {
                roomPageElements.Add(new RoomElement(element));
            }

            return roomPageElements;
        }

        public async Task ClickBookThisRoomButton() => await BookButton.ClickAsync();
    }
}
