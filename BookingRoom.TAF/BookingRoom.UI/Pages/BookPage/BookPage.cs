using BookingRoom.Core.Configuration;
using BookingRoom.UI.Helpers;
using BookingRoom.UI.Pages.BookPage.Components;
using Microsoft.Playwright;

namespace BookingRoom.UI.Pages.BookPage
{
    public class BookPage : BasePage
    {
        public override string? Url => AppConfiguration.TestSettings?.ApplicationUrl;

        public BookPage(IPage page) : base(page)
        {
        }

        private ILocator RoomsElement => Page.Locator("xpath=//div[./*[@class = 'row hotel-room-info']]");

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
            await RoomsElement.WaitForElement(3000);

            var roomsElement = await RoomsElement.AllAsync();


            var roomPageElements = new List<RoomElement>();

            foreach (var element in roomsElement)
            {
                roomPageElements.Add(new RoomElement(element, Page));
            }

            return roomPageElements;
        }
    }
}
