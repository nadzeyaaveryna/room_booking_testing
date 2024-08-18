using BoDi;
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
        private readonly IObjectContainer _objectContainer;

        public BookingRoomSteps(IPage page, IObjectContainer objectContainer)
        {
            _page = page;
            _bookPage = new BookPage(_page);
            _objectContainer = objectContainer;
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

            Assert.AreEqual(rooms.Count == 0, !isPresent, $"At least one room should be {isPresent.ToString()} is the booking list.");
        }

   
        [When(@"Input personal details into form")]
        public void WhenInputPersonalDetailsIntoForm()
        {
            throw new PendingStepException();
        }

        [When(@"Click on ‘Book this room’ button")]
        public void WhenClickOnBookThisRoomButton()
        {
            throw new PendingStepException();
        }

        [Then(@"I check that ‘Book Successful’ dialog appears with correct booking date")]
        public void ThenICheckThatBookSuccessfulDialogAppearsWithCorrectBookingDate()
        {
            throw new PendingStepException();
        }
    }
}
