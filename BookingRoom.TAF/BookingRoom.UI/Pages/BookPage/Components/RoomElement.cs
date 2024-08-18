using BookingRoom.Core.BusinessObjects;
using Microsoft.Playwright;

namespace BookingRoom.UI.Pages.BookPage.Components
{
    public class RoomElement
    {
        private readonly ILocator _rootElement;

        public RoomElement(ILocator rootElement)
        {
            _rootElement = rootElement;
        }

        private ILocator ImageElement => _rootElement.Locator(".hotel-img");
        private ILocator? TypeElement => _rootElement.Locator("h3");
        private ILocator? DescriptionElement => _rootElement.Locator("p");
        private ILocator? WheelchairAccessElement => _rootElement.Locator(".wheelchair");
        private IEnumerable<ILocator> AmenitiesElements => _rootElement.Locator("ul li").AllAsync().Result;
        private ILocator? BookButton => _rootElement.Locator(".openBooking");

        public CalendarElement Calendar => new CalendarElement(_rootElement.Locator(".rbc-calendar"));




        public async Task<string> GetImageUrl() => await ImageElement.GetAttributeAsync("src");

        public async Task<string> GetType() => await TypeElement.TextContentAsync();

        public async Task<string> GetDescription() => await DescriptionElement.TextContentAsync();

        public async Task<IEnumerable<string>> GetAmenities()
        {
            var amenities = new List<string>();
            var amenitiesHandles = AmenitiesElements;
            foreach (var item in amenitiesHandles)
            {
                amenities.Add(await item.TextContentAsync());
            }
            return amenities;
        }
        public async Task<bool> HasWheelchairAccess() => WheelchairAccessElement != null;

        public async Task ClickBookButton() => await BookButton.ClickAsync();

        public async Task<Room> ExtractRoomEntityAsync()
        {
            var room = new Room
            {
                Type = await TypeElement.TextContentAsync(),
                Description = await DescriptionElement.TextContentAsync(),
                HasWheelchairAccess = WheelchairAccessElement != null
            };

            foreach (var item in AmenitiesElements)
            {
                room.Amenities.Add(await item.TextContentAsync());
            }

            return room;
        }


    }
}
