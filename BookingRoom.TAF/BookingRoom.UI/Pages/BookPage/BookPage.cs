﻿using BookingRoom.Core.Configuration;
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
            if (Page != null)
            {
                await Page.WaitForSelectorAsync("xpath=//*[@class = 'row hotel-room-info']",
                        new()
                        {
                            Timeout = 3000,
                            State = WaitForSelectorState.Visible
                        })
                    .ConfigureAwait(false);
            }

            var roomsElement = await Page.Locator("xpath=//div[./*[@class = 'row hotel-room-info']]").AllAsync();


                var roomPageElements = new List<RoomElement>();

                foreach (var element in roomsElement)
                {
                    roomPageElements.Add(new RoomElement(element, Page));
                }

                return roomPageElements;
            }

        public async Task ClickBookThisRoomButton() => await BookButton.ClickAsync();
    }
}
