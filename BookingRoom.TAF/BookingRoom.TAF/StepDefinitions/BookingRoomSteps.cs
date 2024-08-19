using BookingRoom.API.Responses;
using BookingRoom.Core.BusinessObjects;
using BookingRoom.Core.Utils.TestsContext;
using BookingRoom.UI.Pages.BookPage;
using BookingRoom.UI.Pages.BookPage.Components;
using Microsoft.Playwright;
using NUnit.Framework;

namespace BookingRoom.TAF.StepDefinitions
{
    [Binding]
    public class BookingRoomSteps
    {
        private readonly IPage _page;
        private readonly BookPage _bookPage;

        public BookingRoomSteps(IPage page)
        {
            _page = page;
            _bookPage = new BookPage(_page);
        }

        [Given(@"I navigate to booking application")]
        public async Task GivenINavigateToBookingApplication()
        {
            await _bookPage.OpenPage();
        }

        [When("Select first room available in booking page")]
        public async Task WhenSelectFirstRoomAvailableInBookingPage()
        {
            var rooms = await _bookPage.GetRoomsList();
            var firstRoom = rooms.FirstOrDefault();
            var roomEntity = await firstRoom.ExtractRoomEntityAsync();
            roomEntity.Index = 0;

            Assert.That(firstRoom, Is.Not.Null.Or.Empty, "Room should be present in booking page");

            TestContextVariable.RoomElement.Set(firstRoom);
            TestContextVariable.Room.Set(roomEntity);
        }


        [When(@"I click ‘Book this room’ button for selected room")]
        public async Task WhenIClickBookThisRoomButtonForSelectedRoom()
        {
            var room = TestContextVariable.RoomElement.Get<RoomElement>();

            Assert.That(room, Is.Not.Null, "Room should is not registered is object container.");

            await room.ClickBookButton();
        }

        [Then("Check that at least one room is ('(?:present|not present)') in the list")]

        public async Task ThenCheckThatAtLeasOneRoomIsPresentInTheList(bool isPresent)
        {
            var rooms = await _bookPage.GetRoomsList();

            Assert.That(rooms.Count == 0, Is.EqualTo(!isPresent), $"At least one room should be {isPresent.ToString()} is the booking list.");
        }

        [Then("Check that room details are correct")]
        public void ThenCheckThatNecessaryElementsPresentOnRoomCard()
        {
            var roomElement = TestContextVariable.RoomElement.Get<RoomElement>();
            var expectedRoom = TestContextVariable.ExpectedRoom.Get<OneRoom>();

            Assert.Multiple( async () =>
            {
                Assert.That(await roomElement.GetType(), Is.EqualTo(expectedRoom.Type), "Room type is incorrect.");
                Assert.That(await roomElement.GetDescription(), Is.EqualTo(expectedRoom.Description), "Room description is incorrect.");
                Assert.That(await roomElement.GetAmenities(), Is.EqualTo(expectedRoom.Features), "Room features are incorrect.");
                Assert.That(await roomElement.HasWheelchairAccess(), Is.EqualTo(expectedRoom.Accessible), "Room accessibility is incorrect.");
                Assert.That(await roomElement.GetImageUrl(), Is.EqualTo(expectedRoom.Image), "Room image is incorrect.");
            });

        }

    }
}
